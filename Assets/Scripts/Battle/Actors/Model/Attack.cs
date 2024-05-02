using System;
using Atomic.Elements;
using Configs.Abilities;

namespace Battle.Actors.Model
{
    [Serializable]
    public sealed class Attack
    {
        public AtomicVariable<AbilityConfig> weapon;
    }
}