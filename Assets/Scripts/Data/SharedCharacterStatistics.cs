using System;
using Atomic.Elements;

namespace Data
{
    [Serializable]
    public class SharedCharacterStatistics
    {
        private CharacterStatistic _stats;
        public AtomicVariable<int> maxHealth=new ();
        public AtomicVariable<int> health=new ();
        public AtomicVariable<int> maxMana=new ();
        public AtomicVariable<int> mana=new ();
        
        public AtomicVariable<float> attackSpeed=new ();
        public AtomicVariable<float> criticalChance=new ();
        public AtomicVariable<float> criticalRate=new ();

        public AtomicVariable<int> attackPower=new ();
        public AtomicVariable<int> defense=new ();
        public AtomicVariable<float> evasion=new ();

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