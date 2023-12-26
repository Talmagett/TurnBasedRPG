using System;
using Battle.Abilities;
using Battle.AbilityContainers;
using Battle.Core;
using UnityEngine;
using UnityEngine.UI;

namespace Battle.UI
{
    public class AbilitiesView:MonoBehaviour
    {
        [SerializeField] private AbilityHolder abilityHolder;
        [SerializeField] private GameObject view;
        [SerializeField] private Transform container;
        [SerializeField] private Image unitIcon;
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
            view.gameObject.SetActive(team.IsPlayer);
            if (!team.IsPlayer) 
                return;
            
            BuildAbilities(selectedUnit);
        }

        private void BuildAbilities(BattleUnit battleUnit)
        {
            unitIcon.sprite = battleUnit.Data.Icon;
            for (int i = 0; i < battleUnit.Data.AbilityContainers.Length; i++)
            {
                Instantiate(abilityHolder,container).SetData(battleUnit.Data.AbilityContainers[i],battleUnit.Abilities[i]);
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