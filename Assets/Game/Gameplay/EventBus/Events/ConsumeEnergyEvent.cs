using Game.GameEngine.Entities.Scripts;

namespace Game.Gameplay.EventBus.Events
{
    public readonly struct ConsumeEnergyEvent : IEvent
    {
        public readonly IEntity Entity;
        public readonly int Cost;

        public ConsumeEnergyEvent(IEntity entity, int cost)
        {
            Entity = entity;
            Cost = cost;
        }
    }
}