using System;
using System.Linq;
using Sirenix.OdinInspector;
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
            var levelMax =  abilities.Where(t=>t.Level>0);
            var abilitiesToReturn = levelMax.Select(t => t.GetAbility()).ToArray();
            return abilitiesToReturn;
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
        [SerializeField, MinValue(0)] private int defaultLevel;
        [SerializeField, MinValue(1)] private int maxLevel;

        private HeroAbility(AbilityUpgrade[] upgrades, int defaultLevel, int maxLevel)
        {
            abilities = upgrades;
            this.defaultLevel = defaultLevel;
            this.maxLevel = maxLevel;
            Level = this.defaultLevel;
        }

        public int Level { get; private set; }
        public bool IsMaxLevel() => Level >= maxLevel-1;

        public void SetupLevel(int level)
        {
            Level = level;
        }
        
        public AbilityConfig GetAbility()
        {
            return abilities[Level-1].GetAbility();
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
        
        [Serializable]
        public class AbilityUpgrade
        {
            [SerializeField] private AbilityConfig abilityConfig;
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