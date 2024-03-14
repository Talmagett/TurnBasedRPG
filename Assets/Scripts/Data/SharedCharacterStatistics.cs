using UniRx;

namespace Data
{
    public class SharedCharacterStatistics
    {
        private readonly CharacterStatistic _stats;
        public ReactiveProperty<float> AttackSpeed;
        public ReactiveProperty<float> CriticalChance;
        public ReactiveProperty<float> CriticalRate;

        public ReactiveProperty<int> Damage;

        public ReactiveProperty<int> Defense;
        public ReactiveProperty<float> Evasion;
        public ReactiveProperty<int> Health;
        public ReactiveProperty<int> MagicPower;
        public ReactiveProperty<int> Mana;

        public ReactiveProperty<int> MaxHealth;

        public ReactiveProperty<int> MaxMana;

        public SharedCharacterStatistics(CharacterStatistic stats)
        {
            _stats = stats;
            MaxHealth = new ReactiveProperty<int>(stats.Health);
            Health = new ReactiveProperty<int>(stats.Health);
            MaxMana = new ReactiveProperty<int>(stats.Mana);
            Mana = new ReactiveProperty<int>(stats.Mana);
            Damage = new ReactiveProperty<int>(stats.Damage);
            MagicPower = new ReactiveProperty<int>(stats.MagicPower);
            Defense = new ReactiveProperty<int>(stats.Defense);

            AttackSpeed = new ReactiveProperty<float>(stats.AttackSpeed);
            Evasion = new ReactiveProperty<float>(stats.Evasion);
            CriticalChance = new ReactiveProperty<float>(stats.CriticalChance);
            CriticalRate = new ReactiveProperty<float>(stats.CriticalRate);
        }
    }
}