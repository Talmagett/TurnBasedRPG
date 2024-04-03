using System;
using System.Linq;
using Battle.Actors;
using Battle.Characters;
using Battle.EventBus.Game.Pipeline.Turn;
using Configs.Abilities;
using Configs.Character;
using Configs.Enums;
using Game;
using UnityEngine;
using Visual.UI.Battle;
using Zenject;

namespace Battle
{
    public class HeroAbilitiesPresenter : MonoBehaviour
    {
        [SerializeField] private Transform spellsViewParent;
        [SerializeField] private BattleAbilityView battleAbilityView;
        private AbilitiesStorage _abilitiesStorage;

        private ActorData _hero;

        private bool _isChoosing;

        [Inject]
        public void Construct(AbilitiesStorage abilitiesStorage)
        {
            _abilitiesStorage = abilitiesStorage;
        }
        
        private void OnEnable()
        {
            ServiceLocator.Instance.BattleController.BattleQueue.OnCharacterChanged += OnCharacterChanged;
        }

        private void OnDisable()
        {
            ServiceLocator.Instance.BattleController.BattleQueue.OnCharacterChanged -= OnCharacterChanged;
        }

        private void OnCharacterChanged(BattleActor unit)
        {
            Clear();
            if(unit.ActorData.Owner==Owner.Player)
                SetHero(unit.ActorData);
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(1)) _isChoosing = false;
        }

        private void SetHero(ActorData hero)
        {
            _isChoosing = false;
            _hero = hero;
            var heroAbilities = _abilitiesStorage.AbilitiesPacks.FirstOrDefault(t => t.ID == _hero.ID);
            if (heroAbilities == null)
                throw new NullReferenceException($"No ability pack with this id {_hero.ID}");

            foreach (var ability in heroAbilities.Abilities)
            {
                var abilityView = Instantiate(battleAbilityView, spellsViewParent);
                abilityView.AbilityConfig = ability;
                abilityView.CharacterIconView.SetIcon(ability.Icon);
                abilityView.OnClicked += OnAbilityClicked;
            }
        }

        private void OnAbilityClicked(AbilityConfig abilityConfig)
        {
            var target = abilityConfig.TargetType switch
            {
                AbilityTargetType.Ally => ServiceLocator.Instance.BattleController.GetRandomAlly(_hero.Owner),
                AbilityTargetType.Enemy => ServiceLocator.Instance.BattleController.GetRandomEnemy(_hero.Owner),
                _ => _hero
            };
            
            abilityConfig.GetAbilityClone(_hero, target);
            
            //_isChoosing = true;
        }

        private void Clear()
        {
            while (spellsViewParent.transform.childCount > 0)
                DestroyImmediate(spellsViewParent.transform.GetChild(0).gameObject);
        }
    }
}