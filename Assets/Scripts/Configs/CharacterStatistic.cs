using System;
using Sirenix.OdinInspector;

namespace Configs
{
    [Serializable]
    public class CharacterStatistic
    {
        [MinValue(0)] public int Health;

        [MinValue(0)] public int Mana;

        public int AttackPower;

        public int Defense;

        [PropertyRange(0.1f, 10f)] public float AttackSpeed = 1;

        [PropertyRange(0, 1)] public float Evasion;

        [PropertyRange(0, 1)] public float CriticalChance;

        [PropertyRange(0, 5)] public float CriticalRate = 1.5f;
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