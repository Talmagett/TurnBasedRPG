using UnityEngine;

namespace Game.Gameplay.EventBus.Events
{
    public readonly struct VisualParticleEvent : IEvent
    {
        public readonly Transform Target;
        public readonly ParticleSystem Particle;
        public readonly float Duration;

        public VisualParticleEvent(Transform target, ParticleSystem particle, float duration = 2)
        {
            Target = target;
            Particle = particle;
            Duration = duration;
        }
    }
}