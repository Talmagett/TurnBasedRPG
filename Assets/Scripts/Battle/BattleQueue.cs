using System;
using System.Collections.Generic;
using Actors;
using Cysharp.Threading.Tasks;
using Map.Characters;
using Sirenix.OdinInspector;
using Random = UnityEngine.Random;

namespace Battle
{
    [Serializable]
    public class BattleQueue
    {
        public const float QueueTime = 10;

        [ReadOnly] [ShowInInspector] private readonly PriorityQueue _queue = new();

        [ReadOnly] [ShowInInspector] private readonly List<Actor> _unitList = new();

        private bool _isInit = true;

        [ReadOnly] [ShowInInspector] public float CurrentTime { get; private set; }

        public Actor CurrentCharacter { get; private set; }
        public event Action OnQueueChanged;

        public UnitTime[] GetUnitTimes()
        {
            return _queue.GetUnitTimes();
        }

        public void AddUnits(IEnumerable<Actor> units)
        {
            foreach (var unit in units) AddUnit(unit);

            OnQueueChanged?.Invoke();
        }

        public void AddUnit(Actor unit)
        {
            _unitList.Add(unit);
            AddUnitToQueue(unit);
        }

        public void RemoveUnit(Actor unit)
        {
            _unitList.Remove(unit);
            RemoveUnitFromQueue(unit);
            OnQueueChanged?.Invoke();
        }

        public void UpdateTime()
        {
            foreach (var unit in _unitList) AddUnitToQueue(unit);
        }

        private void AddUnitToQueue(Actor unit)
        {
            var lastUnitTime = _queue.GetLatestUnitTime(unit);
            var lastTime = lastUnitTime?.time ?? CurrentTime;
            var attackSpeedDelta = unit.stats.attackSpeed.Value;
            while (lastTime + attackSpeedDelta < CurrentTime + QueueTime)
            {
                lastTime += attackSpeedDelta + (_isInit ? Random.Range(0f, 10) : 0);
                _queue.Enqueue(new UnitTime { character = unit, time = lastTime });
            }
        }

        private void RemoveUnitFromQueue(Actor unit)
        {
            _queue.RemoveUnit(unit);
        }

        public void NextTurn()
        {
            if (_queue.IsEmpty)
                return;

            _isInit = false;

            var unitTime = _queue.Dequeue();
            if(CurrentCharacter!=null)
                CurrentCharacter.Deselect();
            CurrentCharacter = unitTime.character;
            CurrentTime = unitTime.time;
            CurrentCharacter.Select();
            UpdateTime();
            OnQueueChanged?.Invoke();
        }
    }
}