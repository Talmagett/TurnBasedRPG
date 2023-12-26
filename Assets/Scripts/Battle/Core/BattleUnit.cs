using System;
using System.Collections.Generic;
using Battle.Abilities;
using Battle.AbilityContainers;
using Battle.Player;
using Data.BattleUnitData;
using Sirenix.Utilities;
using UnityEngine;

namespace Battle.Core
{
    public class BattleUnit : MonoBehaviour
    {
        public static event Action<BattleUnit> OnSelected;
        
        [field:SerializeField] public BattleUnitData Data { get; private set; }
        [Space]
        [SerializeField] private GameObject selectedVisual;
        public bool IsMoving { get; private set; }
        [field:SerializeField] public BodyParts BodyParts { get; private set; }
        
        public readonly List<Ability> Abilities = new List<Ability>();
        private Team _team;

        public bool IsPlayer()
        {
            return _team.IsPlayer;
        }

        public void Init()
        {
            _team = GetComponent<Team>();
            
            EndTurn();

            IAbilityCaster caster=IsPlayer()?ServiceLocator.Instance.GetPlayerController():GetComponent<AI.AI>();
            foreach (var abilityContainer in Data.AbilityContainers)
            {
                Abilities.Add(abilityContainer.CreateAbility(this, caster));
            }
        }

        public void StartTurn()
        {
            IsMoving = true;
            selectedVisual.SetActive(true);
            OnSelected?.Invoke(this);
        }

        public void EndTurn()
        {
            IsMoving = false;
            selectedVisual.SetActive(false);
        }
    }
}