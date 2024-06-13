using Game.GameEngine.Entities.Scripts;

namespace Game.Gameplay.EventBus.Events
{
    public readonly struct DealDamageEvent : IEvent
    {
        public readonly IEntity Source;
        public readonly IEntity Target;
        public readonly int Damage;
        public readonly float Penetration;
        public DealDamageEvent(IEntity source, IEntity target, int damage, float penetration)
        {
            Source = source;
            Target = target;
            Damage = damage;
            Penetration = penetration;
        }
    }
}