using System;
using Atomic.Elements;

namespace Character.Components
{
    [Serializable]
    public sealed class Component_Life
    {
        public AtomicVariable<bool> isDead = new(false);

        public AtomicVariable<int> health;
        public AtomicVariable<int> maxHealth;

        public Component_Life(int baseHealth)
        {
            health = new AtomicVariable<int>(baseHealth);
            maxHealth = new AtomicVariable<int>(baseHealth);
        }
    }
}