using Battle.AbilityContainers;
using Battle.Core;
using Battle.Player;
using Components;
using Components.Stats;
using UnityEngine;

namespace Battle.Abilities
{
    public class SelfHealAbility:Ability
    {
        private SelfHealAbilityContainer.Data _data;
        public SelfHealAbility(SelfHealAbilityContainer.Data dto,BattleUnit battleUnit, IAbilityCaster caster) : base(battleUnit, caster)
        {
            _data = dto;
        }

        public override void StartAbility()
        {
            if (BattleUnit.TryGetComponent(out Health health))
            {
                //health.Heal(_data.BaseHeal+health.GetMaxHealth()*0.15f);
                GameObject.Instantiate(_data.HealEffect, BattleUnit.BodyParts.Chest.transform.position,Quaternion.identity);
            }

            Debug.Log(BattleUnit.name+" was healing");
            BattleUnit.EndTurn();
        }
    }
}