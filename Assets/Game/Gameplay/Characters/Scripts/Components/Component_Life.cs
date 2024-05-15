using System;
using Atomic.Elements;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Gameplay.Characters.Scripts.Components
{
    [Serializable]
    public sealed class Component_Life
    {
        [ReadOnly]
        public AtomicVariable<bool> isDead = new(false);

        public AtomicVariable<int> maxHealth;
        [ReadOnly]
        public AtomicVariable<int> health;
        
        public Component_Life(int baseHealth)
        {
            health = new AtomicVariable<int>(baseHealth);
            maxHealth = new AtomicVariable<int>(baseHealth);
        }
    }
}