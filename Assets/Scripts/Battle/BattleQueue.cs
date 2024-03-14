using System;
using System.Collections.Generic;
using System.Linq;
using Map.Characters;
using SystemCode;
using Random = UnityEngine.Random;

namespace Battle
{
    [Serializable]
    public class BattleQueue
    {
        private const float QueueTime = 100;
        public float CurrentTime { get; private set; }
        public BaseCharacter CurrentCharacter { get; private set; }
        
        private readonly List<BaseCharacter> _unitList = new();
        private readonly PriorityQueue<BaseCharacter, float> _queues = new();
        private bool _isInit=true;
        public List<UnitTimes> GetUnitTimes()
        {
            var unitTimesArray = new List<UnitTimes>();
            foreach (var (element, priority) in _queues.UnorderedItems)
                unitTimesArray.Add(new UnitTimes(element, priority));
            return unitTimesArray;
        }

        public void AddUnits(IEnumerable<BaseCharacter> units)
        {
            foreach (var unit in units) 
                AddUnit(unit);
        }

        public void AddUnit(BaseCharacter unit)
        {
            _unitList.Add(unit);
            AddUnitTime(unit);
        }

        private void UpdateTime()
        {
            foreach (var unit in _unitList) AddUnitTime(unit);
        }

        private void AddUnitTime(BaseCharacter unit)
        {
            var unitTimes = _queues.UnorderedItems.Where(t => t.Element == unit).ToArray();
            var lastTime = !unitTimes.Any() ? CurrentTime : unitTimes.Max(t => t.Priority);
            while (lastTime + unit.Stats.AttackSpeed.Value < CurrentTime + QueueTime)
            {
                lastTime += unit.Stats.AttackSpeed.Value+(_isInit?Random.Range(0f,10):0);
                _queues.Enqueue(unit, lastTime);
            }
        }

        public void NextTurn()
        {
            if (_queues.Count == 0)
                return;
            if (!_queues.TryDequeue(out var baseCharacter, out var time))
                return;
            if (baseCharacter == null)
                NextTurn();
            _isInit = false;
            
            CurrentCharacter = baseCharacter;
            
            CurrentTime = time;
            UpdateTime();
        }

        [Serializable]
        public class UnitTimes
        {
            public BaseCharacter Character { get; }
            public float Time { get; }

            public UnitTimes(BaseCharacter character, float time)
            {
                Character = character;
                Time = time;
            }
        }
    }
}