using System;
using System.Collections.Generic;
using System.Linq;
using Map.Characters;
using Sirenix.OdinInspector;
using Random = UnityEngine.Random;

namespace Battle
{
    [Serializable]
    public class BattleQueue
    {
        public event Action OnQueueChanged;
        private const float QueueTime = 100;
        [ReadOnly]
        [ShowInInspector]
        public float CurrentTime { get; private set; }
        public BaseCharacter CurrentCharacter { get; private set; }
        [ReadOnly]
        [ShowInInspector]
        private readonly List<BaseCharacter> _unitList = new();

        private readonly PriorityQueue _queue = new PriorityQueue();
        
        private bool _isInit=true;

        public UnitTime[] GetUnitTimes() => _queue.GetUnitTimes();

        public void AddUnits(IEnumerable<BaseCharacter> units)
        {
            foreach (var unit in units)
            {
                AddUnit(unit);
            }
            OnQueueChanged?.Invoke();
        }

        public void AddUnit(BaseCharacter unit)
        {
            _unitList.Add(unit);
            AddUnitTime(unit);
        }

        public void RemoveUnit(BaseCharacter unit)
        {
            _unitList.Remove(unit);
            //RemoveUnitTime();
            UpdateTime();
            OnQueueChanged?.Invoke();
        }

        public void UpdateTime()
        {
            foreach (var unit in _unitList)
            {
                AddUnitTime(unit);
            }
        }

        private void AddUnitTime(BaseCharacter unit)
        {
            _queue.GetFirstUnitTime();
            /*var unitTimes = _queue.Where(t => t.character == unit).ToList();
            var lastTime = !unitTimes.Any() ? CurrentTime : unitTimes.Max(t => t.time);
            while (lastTime + unit.Stats.AttackSpeed.Value < CurrentTime + QueueTime)
            {
                lastTime += unit.Stats.AttackSpeed.Value+(_isInit?Random.Range(0f,10):0);
                _queue.Add(new UnitTime(){character = unit,time = lastTime});
            }*/
        }

        public void NextTurn()
        {
            if (_queue.IsEmpty)
                return;
            
            _isInit = false;

            var unitTime = _queue.GetFirstUnitTime();

            CurrentCharacter = unitTime.character;
            CurrentTime = unitTime.time;
            UpdateTime();
            OnQueueChanged?.Invoke();
        }

        [Serializable]
        public class UnitTime
        {
            public BaseCharacter character;
            public float time;
        }

        public class PriorityQueue
        {
            public bool IsEmpty=> !_queue.Any();
            private List<UnitTime> _queue = new List<UnitTime>();

            public UnitTime[] GetUnitTimes()
            {
                var unitTimesArray=new UnitTime[_queue.Count];
                _queue.CopyTo(unitTimesArray);
                return unitTimesArray;
            }
            
            public UnitTime GetFirstUnitTime()
            {
                return _queue.ElementAt(0);
            }
            
            public void Add(UnitTime unitTime)
            {
                _queue.Add(unitTime);
                Sort();
            }

            public void Remove(UnitTime unitTime)
            {
                _queue.Remove(unitTime);
                Sort();
            }
            
            private void Sort()
            {
                _queue=_queue.OrderByDescending(t => t.time).ToList();
            }
        }
    }
}