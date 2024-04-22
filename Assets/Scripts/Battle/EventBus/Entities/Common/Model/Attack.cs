using System;
using Battle.EventBus.Utils;
using Configs.Abilities;

namespace Battle.EventBus.Entities.Common.Model
{
    [Serializable]
    public sealed class Attack
    {
        public AtomicVariable<AbilityConfig> weapon;
    }
}