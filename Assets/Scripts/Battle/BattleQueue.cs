using System;
using System.Collections.Generic;
using System.Linq;
using Battle.Characters;
using Configs.Enums;
using PrimeTween;
using Sirenix.OdinInspector;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Battle
{
    [Serializable]
    public class BattleQueue
    {
        [ReadOnly] [SerializeField]  private PriorityQueue _queue = new();
        [ReadOnly] [ShowInInspector] private readonly List<BattleActor> _unitList = new();

        [ReadOnly] [ShowInInspector] public readonly float QueueTime = 10;
        private float _currentTime;

        public BattleActor CurrentCharacter { get; private set; }
        private bool _isInit = true;

        public void Clear()
        {
            CurrentCharacter = null;
            _currentTime = 0;
            _isInit = false;
            _queue.Clear();
            _unitList.Clear();
        }

        public event Action OnQueueChanged;
        public event Action<float> OnTimeChanged;

        public UnitTime[] GetUnitTimes()
        {
            return _queue.GetUnitTimes();
        }

        public void AddUnits(IEnumerable<BattleActor> units)
        {
            foreach (var unit in units)
                AddUnit(unit);

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

        public void ChangeTime(BattleActor unit, float additiveTime, float duration)
        {
            _queue.ChangeTime(unit, additiveTime, duration+_currentTime);
        }

        private void AddUnitToQueue(BattleActor unit)
        {
            var lastUnitTime = _queue.GetLatestUnitTime(unit);
            var lastTime = lastUnitTime?.time ?? _currentTime;
            var attackSpeedDelta = unit.ActorData.SharedStats.GetStat(StatKey.AttackSpeed);
            while (lastTime + attackSpeedDelta < _currentTime + QueueTime)
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
            Tween.Custom(_currentTime, unitTime.time, 0.4f, t =>
                {
                    _currentTime = t;
                    OnTimeChanged?.Invoke(_currentTime);
                    UpdateTime();
                })
                .OnComplete(() =>
                {
                    //UpdateTime();
                    CurrentCharacter.ActorData.Select();
                });
        }
    }
}