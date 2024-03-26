using Atomic.Objects;
using UnityEngine;

namespace EventBus.Game.Events
{
    public readonly struct VisualParticleEvent : IEvent
    {
        public readonly IAtomicObject Target;
        public readonly ParticleSystem Particle;

        public VisualParticleEvent(IAtomicObject target, ParticleSystem particle)
        {
            Target = target;
            Particle = particle;
        }
        
    }
}