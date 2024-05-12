using Entities;

namespace EventBus.Events.Effects
{
    public struct MultiDamageEffectEvent : IEffect
    {
        public int Count;
        public DealDamageEffectEvent DealDamageEffectEvent;
        public IEntity Source { get; set; }
        public IEntity Target { get; set; }
    }
}