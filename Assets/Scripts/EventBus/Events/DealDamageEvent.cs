using Entities;

namespace EventBus.Events
{
    public readonly struct DealDamageEvent : IEvent
    {
        public readonly IEntity Source;
        public readonly IEntity Target;
        public readonly int Damage;

        public DealDamageEvent(IEntity source, IEntity target, int damage)
        {
            Source = source;
            Target = target;
            Damage = damage;
        }
    }
}