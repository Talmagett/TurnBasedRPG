using System;
using Atomic.Objects;
using UnityEngine;

namespace EventBus.Events.Effects
{
    [Serializable]
    public struct StunEffectEvent : IEffect
    {
        [field: SerializeField] public int Duration { get; private set; }

        [field: SerializeField] public ParticleSystem HitEffect { get; private set; }

        public IAtomicObject Source { get; set; }
        public IAtomicObject Target { get; set; }
    }
}