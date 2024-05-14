using System;
using Atomic.Elements;
using UnityEngine;

namespace Game.Gameplay.Characters.Scripts.Components
{
    [Serializable]
    public sealed class Component_Life
    {
        public AtomicVariable<bool> isDead = new(false);

        [Min(0)] public AtomicVariable<int> health;

        public AtomicVariable<int> maxHealth;

        public Component_Life(int baseHealth)
        {
            health = new AtomicVariable<int>(baseHealth);
            maxHealth = new AtomicVariable<int>(baseHealth);
        }
    }
}