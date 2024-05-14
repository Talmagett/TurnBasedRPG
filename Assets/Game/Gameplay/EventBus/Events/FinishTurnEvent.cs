using Game.GameEngine.Entities.Scripts;

namespace Game.Gameplay.EventBus.Events
{
    public readonly struct FinishTurnEvent : IEvent
    {
        public readonly IEntity Source;

        public FinishTurnEvent(IEntity source)
        {
            Source = source;
        }
    }
}