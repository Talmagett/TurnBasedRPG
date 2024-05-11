using Atomic.Objects;
using Entities;

namespace EventBus.Events
{
    public readonly struct DestroyCharacterEntityEvent : IEvent
    {
        public readonly IEntity Entity;

        public DestroyCharacterEntityEvent(IEntity entity)
        {
            Entity = entity;
        }
    }
}