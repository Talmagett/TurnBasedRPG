using EventBus.Game;
using EventBus.Utils;

namespace EventBus.Entities.Common.Components
{
    public sealed class WeaponComponent
    {
        public AbilityConfig Value => _weapon;
        
        private readonly AtomicVariable<AbilityConfig> _weapon;

        public WeaponComponent(AtomicVariable<AbilityConfig> weapon)
        {
            _weapon = weapon;
        }
    }
}