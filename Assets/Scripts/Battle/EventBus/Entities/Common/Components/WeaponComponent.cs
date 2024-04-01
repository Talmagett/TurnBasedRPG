using Battle.EventBus.Utils;
using Configs;
using Configs.Abilities;

namespace Battle.EventBus.Entities.Common.Components
{
    public sealed class WeaponComponent
    {
        private readonly AtomicVariable<AbilityConfig> _weapon;

        public WeaponComponent(AtomicVariable<AbilityConfig> weapon)
        {
            _weapon = weapon;
        }

        public AbilityConfig Value => _weapon;
    }
}