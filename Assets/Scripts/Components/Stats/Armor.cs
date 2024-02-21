namespace Components.Stats
{
    public class Armor : Statistic
    {
        public Armor(float baseValue) : base(baseValue)
        {
        }

        public float ArmorMultiplier()
        {
            if (Value >= 0)
                return 100 / (100 + Value);
            return 2 - 100 / (100 - Value);
        }
    }
}