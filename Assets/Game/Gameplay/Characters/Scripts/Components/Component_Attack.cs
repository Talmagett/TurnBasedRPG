using System;
using Atomic.Elements;
using Game.Gameplay.Abilities.Scripts;

namespace Game.Gameplay.Characters.Scripts.Components
{
    [Serializable]
    public sealed class Component_Attack
    {
        public AtomicVariable<AbilityConfig> weapon;
        public AtomicVariable<float> attackPower;
        public AtomicVariable<float> criticalChance;
        public AtomicVariable<float> criticalRate;

        public Component_Attack(int baseAttackPower, float baseCriticalChance, float baseCriticalRate)
        {
            attackPower = new AtomicVariable<float>(baseAttackPower);
            criticalChance = new AtomicVariable<float>(baseCriticalChance);
            criticalRate = new AtomicVariable<float>(baseCriticalRate);
        }
    }
}