using Atomic.Objects;
using Entities;

namespace Battle.EventBus.Game.Events
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