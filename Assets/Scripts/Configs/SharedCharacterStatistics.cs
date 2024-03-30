using System;
using System.Collections.Generic;

namespace Configs
{
    [Serializable]
    public class SharedCharacterStatistics
    {
        public Dictionary<StatKeys, float> Stats = new();

        public void Init(CharacterStatistic stats)
        {
            Stats.Add(StatKeys.MaxHealth, stats.Health);
            Stats.Add(StatKeys.Health, stats.Health);
            Stats.Add(StatKeys.MaxMana, stats.Health);
            Stats.Add(StatKeys.Mana, stats.Health);
            Stats.Add(StatKeys.AttackPower, stats.Health);
            Stats.Add(StatKeys.Defense, stats.Health);
            Stats.Add(StatKeys.AttackSpeed, stats.Health);
            Stats.Add(StatKeys.Evasion, stats.Health);
            Stats.Add(StatKeys.CriticalChance, stats.Health);
            Stats.Add(StatKeys.CriticalRate, stats.Health);
        }
    }
}