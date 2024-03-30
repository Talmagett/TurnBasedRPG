using System;
using System.Collections.Generic;
using Battle.Actors;
using Configs;
using Sirenix.OdinInspector;
using Random = UnityEngine.Random;

namespace Battle
{
    [Serializable]
    public class BattleQueue
    {
        public const float QueueTime = 10;

        [ReadOnly] [ShowInInspector] private readonly PriorityQueue _queue = new();

        [ReadOnly] [ShowInInspector] private readonly List<ActorData> _unitList = new();

        private bool _isInit = true;

        [ReadOnly] [ShowInInspector] public float CurrentTime { get; private set; }

        public ActorData CurrentCharacter { get; private set; }
        public event Action OnQueueChanged;

        public UnitTime[] GetUnitTimes()
        {
            return _queue.GetUnitTimes();
        }

        public void AddUnits(IEnumerable<ActorData> units)
        {
            foreach (var unit in units) AddUnit(unit);

            OnQueueChanged?.Invoke();
        }

        public void AddUnit(ActorData unit)
        {
            _unitList.Add(unit);
            AddUnitToQueue(unit);
        }

        public void RemoveUnit(ActorData unit)
        {
            _unitList.Remove(unit);
            RemoveUnitFromQueue(unit);
            OnQueueChanged?.Invoke();
        }

        public void UpdateTime()
        {
            foreach (var unit in _unitList) AddUnitToQueue(unit);
        }

        private void AddUnitToQueue(ActorData unit)
        {
            var lastUnitTime = _queue.GetLatestUnitTime(unit);
            var lastTime = lastUnitTime?.time ?? CurrentTime;
            var attackSpeedDelta = unit.stats.Stats[StatKeys.AttackSpeed];
            while (lastTime + attackSpeedDelta < CurrentTime + QueueTime)
            {
                lastTime += attackSpeedDelta + (_isInit ? Random.Range(0f, 10) : 0);
                _queue.Enqueue(new UnitTime { character = unit, time = lastTime });
            }
        }

        private void RemoveUnitFromQueue(ActorData unit)
        {
            _queue.RemoveUnit(unit);
        }

        public void NextTurn()
        {
            if (_queue.IsEmpty)
                return;

            _isInit = false;

            var unitTime = _queue.Dequeue();
            if (CurrentCharacter != null)
                CurrentCharacter.Deselect();
            CurrentCharacter = unitTime.character;
            CurrentTime = unitTime.time;
            CurrentCharacter.Select();
            UpdateTime();
            OnQueueChanged?.Invoke();
        }
    }
}