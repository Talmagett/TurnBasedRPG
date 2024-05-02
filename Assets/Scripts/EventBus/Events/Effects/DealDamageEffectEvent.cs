using System;
using Entities;
using UnityEngine;

namespace EventBus.Events.Effects
{
    [Serializable]
    public struct DealDamageEffectEvent : IEffect
    {
        [field: SerializeField] public int ExtraDamage { get; private set; }

        [field: SerializeField] public ParticleSystem HitEffect { get; private set; }

        public IEntity Source { get; set; }
        public IEntity Target { get; set; }
    }
}