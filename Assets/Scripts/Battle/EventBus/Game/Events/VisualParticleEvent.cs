using Atomic.Objects;
using Configs;

namespace Battle.EventBus.Game.Events
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