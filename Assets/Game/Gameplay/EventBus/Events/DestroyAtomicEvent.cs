using Game.GameEngine.Entities.Scripts;

namespace Game.Gameplay.EventBus.Events
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