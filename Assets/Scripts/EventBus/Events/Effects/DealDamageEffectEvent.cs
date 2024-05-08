using System;
using Atomic.Objects;
using Configs.Abilities.Attributes;
using Configs.Character;
using UnityEngine;

namespace EventBus.Events.Effects
{
    [Serializable]
    public struct DealDamageEffectEvent : IEffect
    {
        [field: SerializeField] public ParticleSystem HitEffect { get; private set; }
        [field: SerializeField] public BodyParts.Key HitEffectPoint { get; private set; }
        [field: SerializeField] public AbilityStat DamageAmount { get; private set; }

        public IAtomicObject Source { get; set; }
        public IAtomicObject Target { get; set; }
    }
}