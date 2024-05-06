using System;
using System.Collections.Generic;
using Configs.Enums;
using Sirenix.OdinInspector;

namespace Configs.Character
{
    [Serializable]
    public class BaseCharacterStatsConfig
    {
        [MinValue(0)] public int Health;

        [MinValue(0)] public int Mana;

        public int AttackPower;

        public int Defense;
        
        [PropertyRange(0, 1)] public float Evasion;

        [PropertyRange(0, 1)] public float CriticalChance;

        [PropertyRange(0, 5)] public float CriticalRate = 1.5f;

        public Dictionary<StatKey, float> CloneStats()
        {
            Dictionary<StatKey, float> stats = new();

            stats.Add(StatKey.MaxHealth, Health);
            stats.Add(StatKey.Health, Health);
            stats.Add(StatKey.MaxMana, Mana);
            stats.Add(StatKey.Mana, Mana);
            stats.Add(StatKey.AttackPower, AttackPower);
            stats.Add(StatKey.Defense, Defense);
            stats.Add(StatKey.Energy, 1);
            stats.Add(StatKey.Evasion, Evasion);
            stats.Add(StatKey.CriticalChance, CriticalChance);
            stats.Add(StatKey.CriticalRate, CriticalRate);
            return stats;
        }
    }
}