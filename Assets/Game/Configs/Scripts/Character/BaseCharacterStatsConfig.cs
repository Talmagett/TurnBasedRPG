using System;
using System.Collections.Generic;
using Game.Configs.Configs.Enums;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Configs.Configs.Character
{
    [Serializable]
    public class BaseCharacterStatsConfig
    {
        [MinValue(0)] [SerializeField] private int health;
        [MinValue(0)] [SerializeField] private int mana;
        [SerializeField] private int attackPower;
        [SerializeField] private int defense;
        [PropertyRange(0, 1)] [SerializeField] private float evasion;
        [PropertyRange(0, 1)] [SerializeField] private float criticalChance;
        [PropertyRange(0, 5)] [SerializeField] private float criticalRate = 1.5f;

        public Dictionary<StatKey, float> CloneStats()
        {
            Dictionary<StatKey, float> stats = new();

            stats.Add(StatKey.MaxHealth, health);
            stats.Add(StatKey.MaxMana, mana);
            stats.Add(StatKey.AttackPower, attackPower);
            stats.Add(StatKey.Defense, defense);
            stats.Add(StatKey.Evasion, evasion);
            stats.Add(StatKey.CriticalChance, criticalChance);
            stats.Add(StatKey.CriticalRate, criticalRate);
            return stats;
        }
    }
}