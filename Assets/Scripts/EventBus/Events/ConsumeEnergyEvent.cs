using Atomic.Objects;

namespace EventBus.Events
{
    public readonly struct ConsumeEnergyEvent : IEvent
    {
        public readonly IAtomicObject Entity;
        public readonly int Cost;
        public ConsumeEnergyEvent(IAtomicObject entity, int cost)
        {
            Entity = entity;
            Cost = cost;
        }
    }
}