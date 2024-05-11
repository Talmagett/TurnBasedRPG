using Entities;

namespace EventBus.Events
{
    public struct TurnSelectionEvent : IEvent
    {
        public readonly IEntity Source;
        public readonly bool IsActive;

        public TurnSelectionEvent(IEntity source, bool isActive)
        {
            Source = source;
            IsActive = isActive;
        }
    }
}