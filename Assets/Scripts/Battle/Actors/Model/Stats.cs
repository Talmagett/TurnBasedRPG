using System;
using Atomic.Elements;

namespace Battle.Actors.Model
{
    [Serializable]
    public sealed class Stats
    {
        public AtomicVariable<int> strength;
    }
}