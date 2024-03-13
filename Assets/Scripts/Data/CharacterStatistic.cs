namespace Components
{
    [System.Serializable]
    public class CharacterStatistic
    {
        public int Health;
        public int Mana;
        public int Damage;
        public int MagicPower;
        public int Defense;
        public float AttackSpeed;
        public float Evasion;
        public float CriticalChance;
        public float CriticalRate;
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