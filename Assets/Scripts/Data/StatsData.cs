using Sirenix.OdinInspector;

namespace Data
{
    [System.Serializable]
    public class StatsData
    {
        public int MaxHealth;
        public int Health;
        public int MaxMana;
        public int Mana;
        
        //физический урон
        public int Strength;
        
        //магический урон 
        public int Intelligence;
    }
}