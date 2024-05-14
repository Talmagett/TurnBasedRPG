using Game.GameEngine.Entities.Scripts;

namespace Game.Gameplay.EventBus.Events
{
    public readonly struct StartTurnEvent : IEvent
    {
        public readonly IEntity Source;

        public StartTurnEvent(IEntity source)
        {
            Source = source;
        }
    }
}