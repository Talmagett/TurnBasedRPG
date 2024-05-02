using System;
using Atomic.Elements;

namespace Battle.Actors.Model
{
    [Serializable]
    public sealed class Life
    {
        public AtomicVariable<bool> isDead = new(false);

        public AtomicVariable<int> hitPoints = new(1);
        public AtomicVariable<int> maxHitPoints = new(1);
    }
}