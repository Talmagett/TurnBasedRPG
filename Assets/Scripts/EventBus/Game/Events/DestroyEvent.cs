using Entities;

namespace EventBus.Game.Events
{
    public readonly struct DestroyEvent : IEvent
    {
        public readonly IEntity Entity;

        public DestroyEvent(IEntity entity)
        {
            Entity = entity;
        }
    }
}