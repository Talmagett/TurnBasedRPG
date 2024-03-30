using System;
using Battle.EventBus.Utils;
using Configs;

namespace Battle.EventBus.Entities.Common.Model
{
    [Serializable]
    public sealed class Attack
    {
        public AtomicVariable<Ability> weapon;
    }
}