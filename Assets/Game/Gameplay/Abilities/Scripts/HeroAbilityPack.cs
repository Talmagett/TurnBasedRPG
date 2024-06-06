using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game.Gameplay.Abilities.Scripts
{
    [System.Serializable]
    public class HeroAbilityPack
    {
        [SerializeField] private HeroAbility[] abilities;

        public HeroAbility[] GetAllAbilities()
        {
            return abilities;
        }
        
        public AbilityConfig[] GetAbilitiesWithCurrentLevel()
        {
            return abilities.Select(t => t.GetAbility()).ToArray();
        }
    }

    [System.Serializable]
    public class HeroAbility
    {
        [SerializeField] private AbilityUpgrade[] abilities;
        [SerializeField] private int defaultLevel;
        [SerializeField] private int maxLevel;
        public int Level { get; private set; }
        public bool IsMaxLevel() => Level >= maxLevel;
        
        public AbilityConfig GetAbility()
        {
            return abilities[Level].GetAbility();
        }
        
        public bool TryUpgradeLevel(int money)
        {
            if (IsMaxLevel())
                return false;
            if (!abilities[Level].CanUpgrade(money))
                return false;

            Level++;
            return true;
        }
        
        [System.Serializable]
        public class AbilityUpgrade
        {
            [SerializeField] private AbilityConfig ability;
            [SerializeField] private int cost;

            public bool CanUpgrade(int money)=>money >= cost;
            
            public AbilityConfig GetAbility()
            {
                return ability;
            }
        }
    }
}