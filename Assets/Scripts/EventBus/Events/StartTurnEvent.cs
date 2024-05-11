using Entities;

namespace EventBus.Events
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