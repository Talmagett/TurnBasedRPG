using Game.GameEngine.Entities.Scripts;

namespace Game.Gameplay.EventBus.Events.Effects
{
    public interface IEffect : IEvent
    {
        public IEntity Source { get; set; }
        public IEntity Target { get; set; }
    }
}