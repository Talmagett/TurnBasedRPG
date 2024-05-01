using System;
using Battle.EventBus.Utils;

namespace Battle.EventBus.Entities.Common.Model
{
    [Serializable]
    public sealed class Stats
    {
        public AtomicVariable<int> strength = 1;
    }
}