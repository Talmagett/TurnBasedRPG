using System;
using EventBus.Utils;

namespace EventBus.Entities.Common.Model
{
    [Serializable]
    public sealed class Stats
    {
        public AtomicVariable<int> strength = 1;
    }
}