using Atomic.Objects;

namespace EventBus.Events
{
    public readonly struct FinishTurnEvent : IEvent
    {
        public readonly IAtomicObject Source;

        public FinishTurnEvent(IAtomicObject source)
        {
            Source = source;
        }
    }
}