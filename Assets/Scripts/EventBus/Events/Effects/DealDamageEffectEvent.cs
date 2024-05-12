using System;
using Character.BodyParts;
using Configs.Attributes;
using Entities;
using UnityEngine;

namespace EventBus.Events.Effects
{
    [Serializable]
    public struct DealDamageEffectEvent : IEffect
    {
        [field: SerializeField] public ParticleSystem HitEffect { get; private set; }
        [field: SerializeField] public BodyParts.Key HitEffectPoint { get; private set; }
        [field: SerializeField] public AbilityStat DamageAmount { get; private set; }

        public IEntity Source { get; set; }
        public IEntity Target { get; set; }
    }
}