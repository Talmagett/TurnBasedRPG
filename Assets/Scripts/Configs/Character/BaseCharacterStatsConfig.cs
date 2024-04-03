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

        [MinValue(1)] public int AttackSpeed = 1;

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
            stats.Add(StatKey.ActionRecoverySpeed, AttackSpeed);
            stats.Add(StatKey.Evasion, Evasion);
            stats.Add(StatKey.CriticalChance, CriticalChance);
            stats.Add(StatKey.CriticalRate, CriticalRate);
            return stats;
        }
    }
}

/*
Характеристики:

Power - сила атаки, магии
Durability - HP
Intellect - MP
Defense - защита
Haste - скорость на карте и между атаками
Luck - шанс на уклонение и крита

Статы у всех:

Сила атаки
Сила магии
Здоровье
Мана
Вампиризм
Физ защита
Маг защита
Скорость атаки
Уклонение
Шанс крита
Урон крита

 */