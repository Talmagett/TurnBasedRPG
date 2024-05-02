using Atomic.Objects;

namespace EventBus.Events
{
    public readonly struct DestroyEvent : IEvent
    {
        public readonly IAtomicObject Entity;

        public DestroyEvent(IAtomicObject entity)
        {
            Entity = entity;
        }
    }
}