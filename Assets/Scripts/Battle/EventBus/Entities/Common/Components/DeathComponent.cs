using System;
using Battle.EventBus.Utils;

namespace Battle.EventBus.Entities.Common.Components
{
    public sealed class DeathComponent
    {
        private readonly AtomicVariable<bool> _isDead;

        public DeathComponent(AtomicVariable<bool> isDead)
        {
            _isDead = isDead;
        }

        public bool IsDead => _isDead;

        public event Action<bool> OnIsDeadChanged
        {
            add => _isDead.ValueChanged += value;
            remove => _isDead.ValueChanged -= value;
        }

        public void Die()
        {
            _isDead.Value = true;
        }
    }
}