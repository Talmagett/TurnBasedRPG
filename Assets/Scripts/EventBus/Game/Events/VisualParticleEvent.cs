using Atomic.Objects;
using Data;
using UnityEngine;

namespace EventBus.Game.Events
{
    public readonly struct VisualParticleEvent : IEvent
    {
        public readonly IAtomicObject Target;
        public readonly ParticleStorage.ParticleKeys ParticleKey;

        public VisualParticleEvent(IAtomicObject target, ParticleStorage.ParticleKeys particleKey)
        {
            Target = target;
            ParticleKey = particleKey;
        }
    }
}