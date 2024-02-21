namespace Components.Stats
{
    public class MagicResistance : Statistic
    {
        public MagicResistance(float baseValue) : base(baseValue)
        {
        }

        public float MagicResistanceMultiplier()
        {
            if (Value >= 0)
                return 100 / (100 + Value);
            return 2 - 100 / (100 - Value);
        }
    }
}