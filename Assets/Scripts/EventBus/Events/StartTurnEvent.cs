using Atomic.Objects;

namespace EventBus.Events
{
    public readonly struct StartTurnEvent : IEvent
    {
        public readonly IAtomicObject Source;

        public StartTurnEvent(IAtomicObject source)
        {
            Source = source;
        }
    }
}