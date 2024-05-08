using System;
using Atomic.Objects;
using UnityEngine;

namespace EventBus.Events.Effects
{
    [Serializable]
    public struct DoTEffectEvent : IEffect
    {
        [field: SerializeField] public int Duration { get; private set; }
        [field: SerializeField] public int Damage { get; private set; }
        [field: SerializeField] public ParticleSystem HitEffect { get; private set; }

        public IAtomicObject Source { get; set; }
        public IAtomicObject Target { get; set; }
    }
}