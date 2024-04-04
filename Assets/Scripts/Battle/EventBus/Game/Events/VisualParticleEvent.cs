using Atomic.Objects;
using UnityEngine;

namespace Battle.EventBus.Game.Events
{
    public readonly struct VisualParticleEvent : IEvent
    {
        public readonly Transform Target;
        public readonly ParticleSystem Particle;

        public VisualParticleEvent(Transform target, ParticleSystem particle)
        {
            Target = target;
            Particle = particle;
        }
    }
}