using Game.GameEngine.Entities.Scripts;

namespace Game.Gameplay.EventBus.Events.Effects
{
    public struct MultiDamageEffectEvent : IEffect
    {
        public int Count;
        public float Delay;
        public DealDamageEffectEvent DealDamageEffectEvent;
        public IEntity Source { get; set; }
        public IEntity Target { get; set; }
    }
}