using Atomic.Objects;
using Configs;
using UnityEngine;

namespace Battle.EventBus.Game.Events
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