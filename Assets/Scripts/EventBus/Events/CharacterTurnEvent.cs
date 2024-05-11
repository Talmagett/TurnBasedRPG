using Battle.Actors;
using Entities;

namespace EventBus.Events
{
    public readonly struct CharacterTurnEvent : IEvent
    {
        public readonly IEntity Entity;

        public CharacterTurnEvent(IEntity entity)
        {
            Entity = entity;
        }
    }
}