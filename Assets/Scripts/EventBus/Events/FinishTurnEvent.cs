using Entities;

namespace EventBus.Events
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