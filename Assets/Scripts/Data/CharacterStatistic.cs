using System;
using Sirenix.OdinInspector;

namespace Data
{
    [Serializable]
    public class CharacterStatistic
    {
        [MinValue(0)] public int Health;

        [MinValue(0)] public int Mana;

        [MinValue(0)] public int Damage;

        [MinValue(0)] public int MagicPower;

        public int Defense;

        [PropertyRange(0.1f, 10f)] public float AttackSpeed;

        [PropertyRange(0, 1)] public float Evasion;

        [PropertyRange(0, 1)] public float CriticalChance;

        [PropertyRange(0.1f, 10)] public float CriticalRate;
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