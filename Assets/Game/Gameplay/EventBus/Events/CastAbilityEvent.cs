using Game.GameEngine.Entities.Scripts;
using Game.Gameplay.Abilities.Scripts;

namespace Game.Gameplay.EventBus.Events
{
    public struct CastAbilityEvent : IEvent
    {
        public readonly IEntity Source;
        public readonly IEntity Target;
        public readonly AbilityConfig AbilityConfig;

        public CastAbilityEvent(IEntity source, IEntity target, AbilityConfig abilityConfig)
        {
            Source = source;
            Target = target;
            AbilityConfig = abilityConfig;
        }
    }
}