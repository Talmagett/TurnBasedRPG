using Entities;

namespace Battle.EventBus.Game.Events
{
    public readonly struct AttackEvent : IEvent
    {
        public readonly IEntity Entity;
        public readonly IEntity Target;

        public AttackEvent(IEntity entity, IEntity target)
        {
            Entity = entity;
            Target = target;
        }
    }
}