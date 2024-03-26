using System;
using EventBus.Utils;

namespace EventBus.Entities.Common.Model
{
    [Serializable]
    public sealed class Life
    {
        public AtomicVariable<bool> isDead = false;

        public AtomicVariable<int> hitPoints = 1;
        public AtomicVariable<int> maxHitPoints = 1;
    }
}