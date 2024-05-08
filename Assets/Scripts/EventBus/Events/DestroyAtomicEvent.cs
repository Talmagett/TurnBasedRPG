using Atomic.Objects;

namespace EventBus.Events
{
    public readonly struct DestroyAtomicEvent : IEvent
    {
        public readonly IAtomicObject Entity;

        public DestroyAtomicEvent(IAtomicObject entity)
        {
            Entity = entity;
        }
    }
}