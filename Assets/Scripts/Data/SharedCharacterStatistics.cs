using System;
using Atomic.Elements;

namespace Data
{
    [Serializable]
    public class SharedCharacterStatistics
    {
        private CharacterStatistic _stats;
        public AtomicVariable<int> maxHealth;
        public AtomicVariable<int> health;
        public AtomicVariable<int> maxMana;
        public AtomicVariable<int> mana;
        
        public AtomicVariable<float> attackSpeed;
        public AtomicVariable<float> criticalChance;
        public AtomicVariable<float> criticalRate;

        public AtomicVariable<int> attackPower;
        public AtomicVariable<int> defense;
        public AtomicVariable<float> evasion;

        public void Init(CharacterStatistic stats)
        {
            _stats = stats;
            maxHealth.Value = stats.Health;
            health.Value = stats.Health;
            maxMana.Value = stats.Mana;
            mana.Value = stats.Mana;
            attackPower.Value = stats.AttackPower;
            defense.Value = stats.Defense;
            attackSpeed.Value = stats.AttackSpeed;
            evasion.Value = stats.Evasion;
            criticalChance.Value = stats.CriticalChance;
            criticalRate.Value = stats.CriticalRate;
        }
    }
}