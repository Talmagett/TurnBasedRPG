using System;
using System.Collections.Generic;
using System.Linq;
using Actors;
using Map.Characters;
using Sirenix.OdinInspector;

namespace Battle
{
    [Serializable]
    public class PriorityQueue
    {
        [ReadOnly] [ShowInInspector] private List<UnitTime> _queue = new();

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

        public UnitTime GetLatestUnitTime(ActorData unit)
        {
            var unitTimes = _queue.Where(t => t.character == unit).ToArray();
            return unitTimes.LastOrDefault();
        }

        public void RemoveUnit(ActorData unit)
        {
            var unitTimes = _queue.Where(t => t.character == unit).ToArray();
            foreach (var unitTime in unitTimes) _queue.Remove(unitTime);
        }

        private void Sort()
        {
            _queue = _queue.OrderBy(t => t.time).ToList();
        }
    }
}