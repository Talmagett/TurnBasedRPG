using Game.GameEngine.Entities.Scripts;

namespace Game.Gameplay.EventBus.Events
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