using Components.Stats;

namespace Components.Characters
{
    public class CharacterBase
    {
        public Stats Shared;
        
        [System.Serializable]
        public class Stats
        {
            public Health Health;
            public HealthRegeneration HealthRegeneration;
            public Armor Armor;
            public MagicResistance MagicResistance;
            public Mana Mana;
        }
    }
}