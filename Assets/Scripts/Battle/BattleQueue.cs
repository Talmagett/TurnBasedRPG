using System;
using System.Collections.Generic;
using Battle.Characters;
using Configs.Enums;
using Sirenix.OdinInspector;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Battle
{
    [Serializable]
    public class BattleQueue : IDisposable
    {
        [ReadOnly] [ShowInInspector] private readonly PriorityQueue _queue = new();
        [ReadOnly] [ShowInInspector] private readonly List<BattleActor> _unitList = new();

        [ReadOnly] [ShowInInspector] public readonly float QueueTime = 10;
        private bool _isInit = true;
        [ReadOnly] [ShowInInspector] public float CurrentTime { get; private set; }

        public BattleActor CurrentCharacter { get; private set; }

        public void Dispose()
        {
            _queue.Clear();
            _unitList.Clear();
        }

        public event Action OnQueueChanged;


        public UnitTime[] GetUnitTimes()
        {
            return _queue.GetUnitTimes();
        }

        public void AddUnits(IEnumerable<BattleActor> units)
        {
            foreach (var unit in units)
                AddUnit(unit);
            Debug.Log("queue");

            OnQueueChanged?.Invoke();
        }

        public void AddUnit(BattleActor unit)
        {
            _unitList.Add(unit);
            AddUnitToQueue(unit);
        }

        public void RemoveUnit(BattleActor unit)
        {
            _unitList.Remove(unit);
            RemoveUnitFromQueue(unit);
            OnQueueChanged?.Invoke();
        }

        public void UpdateTime()
        {
            foreach (var unit in _unitList) AddUnitToQueue(unit);
        }

        private void AddUnitToQueue(BattleActor unit)
        {
            var lastUnitTime = _queue.GetLatestUnitTime(unit);
            var lastTime = lastUnitTime?.time ?? CurrentTime;
            var attackSpeedDelta = unit.ActorData.SharedStats.GetStat(StatKey.AttackSpeed);
            while (lastTime + attackSpeedDelta < CurrentTime + QueueTime)
            {
                lastTime += attackSpeedDelta + (_isInit ? Random.Range(0f, 10) : 0);
                _queue.Enqueue(new UnitTime { character = unit, time = lastTime });
            }
        }

        private void RemoveUnitFromQueue(BattleActor unit)
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
                CurrentCharacter.ActorData.Deselect();
            CurrentCharacter = unitTime.character;
            CurrentTime = unitTime.time;
            CurrentCharacter.ActorData.Select();
            UpdateTime();
            OnQueueChanged?.Invoke();
        }
    }
}