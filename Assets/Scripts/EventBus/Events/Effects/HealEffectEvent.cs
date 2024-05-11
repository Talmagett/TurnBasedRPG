using System;
using Atomic.Objects;
using Configs.Abilities.Attributes;
using Configs.Character;
using Entities;
using UnityEngine;

namespace EventBus.Events.Effects
{
    [Serializable]
    public struct HealEffectEvent : IEffect
    {
        [field: SerializeField] public ParticleSystem HitEffect { get; private set; }
        [field: SerializeField] public BodyParts.Key HitEffectPoint { get; private set; }
        [field: SerializeField] public AbilityStat DamageAmount { get; private set; }

        public IEntity Source { get; set; }
        public IEntity Target { get; set; }
    }
}