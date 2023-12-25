using System;
using Battle.Abilities;
using Battle.Core;
using UnityEngine;

namespace Battle.UI
{
    public class AbilitiesView:MonoBehaviour
    {
        [SerializeField] private AbilityHolder abilityHolder;
        [SerializeField] private Transform container;

        private void OnEnable()
        {
            BattleUnit.OnSelected += UpdateVisual;
        }

        private void OnDisable()
        {
            BattleUnit.OnSelected -= UpdateVisual;
        }

        private void UpdateVisual(BattleUnit selectedUnit)
        {
            if (!selectedUnit.TryGetComponent(out Team team)) 
                throw new Exception($"{selectedUnit.name} unit has no Team");
            
            CleanUp();
            
            if (!team.IsPlayer) 
                return;
            
            BuildAbilities(selectedUnit.Abilities);
        }

        private void BuildAbilities(Ability[] abilities)
        {
            foreach (var ability in abilities)
            {
                Instantiate(abilityHolder,container).SetData(ability);
            }
        }

        private void CleanUp()
        {
            for (int i = container.childCount-1; i >=0; i--)
            {
                Destroy(container.GetChild(i).gameObject);
            }
        }
    }
}