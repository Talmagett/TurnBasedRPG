using EventBus.Game;
using EventBus.Utils;

namespace EventBus.Entities.Common.Components
{
    public sealed class WeaponComponent
    {
        public Weapon Value => _weapon;
        
        private readonly AtomicVariable<Weapon> _weapon;

        public WeaponComponent(AtomicVariable<Weapon> weapon)
        {
            _weapon = weapon;
        }
    }
}