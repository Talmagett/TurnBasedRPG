using Entities;

namespace EventBus.Events
{
    public readonly struct CollideEvent : IEvent
    {
        public readonly IEntity Entity;
        public readonly IEntity Target;

        public CollideEvent(IEntity entity, IEntity target)
        {
            Entity = entity;
            Target = target;
        }
    }
}