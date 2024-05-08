using Atomic.Objects;

namespace EventBus.Events.Effects
{
    public interface IEffect : IEvent
    {
        public IAtomicObject Source { get; set; }
        public IAtomicObject Target { get; set; }
    }
}