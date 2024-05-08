using System;
using Atomic.Elements;
using Configs.Abilities;

namespace Battle.Actors.Model
{
    [Serializable]
    public sealed class Attack
    {
        public AtomicVariable<int> energy;
        public AtomicVariable<AbilityConfig> weapon;

        public Attack()
        {
            
        }
    }
}