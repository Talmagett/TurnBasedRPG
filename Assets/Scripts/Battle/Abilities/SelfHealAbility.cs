using Components;
using UnityEngine;

namespace Battle.Abilities
{
    public class SelfHealAbility:Ability
    {
        [SerializeField] private int baseHeal = 15;
        public override void StartAbility()
        {
            if (BattleUnit.TryGetComponent(out Health health))
            {
                health.Heal(baseHeal+health.GetMaxHealth()*0.15f);
            }

            Debug.Log(BattleUnit.name+" was healing");
            BattleUnit.EndTurn();
        }
    }
}