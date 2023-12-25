using System;
using Battle.Abilities;
using Battle.Core;
using Battle.Player;
using UnityEngine;

namespace Battle.AbilityContainers
{
    public class SelfHealAbilityContainer : AbilityContainer
    {
        [SerializeField] private Data data;

        [Serializable]
        public class Data
        {
            [field: SerializeField] public int BaseHeal { get; private set; } = 15;
            [field: SerializeField] public ParticleSystem HealEffect { get; private set; }
        }

        public override Ability CreateAbility(BattleUnit owner, IAbilityCaster casterType)
        {
            return new SelfHealAbility(data, owner, casterType);
        }
    }
}