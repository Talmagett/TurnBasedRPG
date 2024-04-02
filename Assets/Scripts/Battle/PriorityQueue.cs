using System;
using System.Collections.Generic;
using System.Linq;
using Battle.Characters;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Battle
{
    [Serializable]
    public class PriorityQueue
    {
        [ReadOnly] [SerializeField] private List<UnitTime> _queue = new();

        public bool IsEmpty => !_queue.Any();

        public UnitTime[] GetUnitTimes()
        {
            var unitTimesArray = new UnitTime[_queue.Count];
            _queue.CopyTo(unitTimesArray);
            return unitTimesArray;
        }

        public void Enqueue(UnitTime unitTime)
        {
            _queue.Add(unitTime);
            Sort();
        }

        public UnitTime Dequeue()
        {
            var first = _queue.ElementAt(0);
            _queue.Remove(first);

            return first;
        }

        private UnitTime[] GetUnitTimes(BattleActor unit)
        {
            return _queue.Where(t => t.character == unit).ToArray();
        }
        
        public UnitTime GetLatestUnitTime(BattleActor unit)
        {
            var unitTimes = GetUnitTimes(unit);
            return unitTimes.LastOrDefault();
        }

        public void RemoveUnit(BattleActor unit)
        {
            var unitTimes = _queue.Where(t => t.character == unit).ToArray();
            foreach (var unitTime in unitTimes) _queue.Remove(unitTime);
        }

        private void Sort()
        {
            _queue = _queue.OrderBy(t => t.time).ToList();
        }

        public void Clear()
        {
            _queue.Clear();
        }

        public void ChangeTime(BattleActor unit, float additiveTime, float finishingTime)
        {
            var times = GetUnitTimes(unit);
            for (int i = 0; i < times.Length; i++)
            {
                if (times[i].time > finishingTime)
                    return;

                for (int j = i; j < times.Length; j++)
                {
                    times[j].time += additiveTime;
                }
            }
        }
    }
}