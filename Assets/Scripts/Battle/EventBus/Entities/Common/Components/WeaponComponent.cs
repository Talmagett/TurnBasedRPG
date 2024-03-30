using Battle.EventBus.Utils;
using Configs;

namespace Battle.EventBus.Entities.Common.Components
{
    public sealed class WeaponComponent
    {
        private readonly AtomicVariable<Ability> _weapon;

        public WeaponComponent(AtomicVariable<Ability> weapon)
        {
            _weapon = weapon;
        }

        public Ability Value => _weapon;
    }
}