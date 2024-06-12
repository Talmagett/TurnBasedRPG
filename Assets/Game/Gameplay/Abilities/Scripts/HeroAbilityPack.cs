using System;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

namespace Game.Gameplay.Abilities.Scripts
{
    [System.Serializable]
    public class HeroAbilityPack
    {
        [SerializeField] private HeroAbility[] abilities;

        private HeroAbilityPack(HeroAbility[] abilities)
        {
            this.abilities = abilities;
        }

        public HeroAbility[] GetAllAbilities()
        {
            return abilities;
        }
        
        public AbilityConfig[] GetAbilitiesWithCurrentLevel()
        {
            return abilities.Select(t => t.GetAbility()).ToArray();
        }

        public HeroAbilityPack Clone()
        {

            return new HeroAbilityPack(abilities.Select(t => t.Clone()).ToArray());
        }
    }

    [System.Serializable]
    public class HeroAbility
    {
        [SerializeField] private AbilityUpgrade[] abilities;
        [SerializeField] private int defaultLevel;
        [SerializeField] private int maxLevel;

        private HeroAbility(AbilityUpgrade[] upgrades, int defaultLevel, int maxLevel)
        {
            abilities = upgrades;
            this.defaultLevel = defaultLevel;
            this.maxLevel = maxLevel;
        }

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
            [FormerlySerializedAs("ability")] [SerializeField] private AbilityConfig abilityConfig;
            [SerializeField] private int cost;

            private AbilityUpgrade(AbilityConfig abilityConfig, int cost)
            {
                this.abilityConfig = abilityConfig;
                this.cost = cost;
            }

            public bool CanUpgrade(int money)=>money >= cost;
            
            public AbilityConfig GetAbility()
            {
                return abilityConfig;
            }

            public AbilityUpgrade Clone()
            {
                return new AbilityUpgrade(abilityConfig,cost);
            }
        }

        public HeroAbility Clone()
        {
            return new HeroAbility(abilities.Select(t=>t.Clone()).ToArray(),defaultLevel,maxLevel);
        }
    }
}