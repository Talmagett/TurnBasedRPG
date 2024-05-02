namespace EventBus.Events
{
    public readonly struct DelayedEvent : IEvent
    {
        public readonly IEvent NextEvent;
        public readonly float Delay;
        public DelayedEvent(IEvent nextEvent, float delay)
        {
            NextEvent = nextEvent;
            Delay = delay;
        }
    }
}