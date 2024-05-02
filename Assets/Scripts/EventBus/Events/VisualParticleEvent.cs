using UnityEngine;

namespace EventBus.Events
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