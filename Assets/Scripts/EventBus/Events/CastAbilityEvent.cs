using System;
using Atomic.Objects;
using Battle.Actors;
using Configs.Abilities;
using Cysharp.Threading.Tasks;
using Entities;
using EventBus.Events.Effects;
using ModestTree.Util;

namespace EventBus.Events
{
    public struct CastAbilityEvent : IEvent
    {
        public readonly IEntity Source;
        public readonly IEntity Target;
        public readonly AbilityConfig AbilityConfig;
        public CastAbilityEvent(IEntity source, IEntity target, AbilityConfig abilityConfig)
        {
            Source = source;
            Target = target;
            AbilityConfig = abilityConfig;
        }
    }
}