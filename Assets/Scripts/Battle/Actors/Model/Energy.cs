using System;
using Atomic.Elements;
using Configs.Abilities;

namespace Battle.Actors.Model
{
    [Serializable]
    public sealed class Energy
    {
        public AtomicVariable<int> Value;
    }
}