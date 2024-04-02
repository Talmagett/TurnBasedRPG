using System;
using System.Linq;
using Battle.Actors;
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
        private EventBus.Game.EventBus _eventBus;

        private ActorData _hero;

        private bool _isChoosing;
        private TurnPipeline _turnPipeline;

        private void Update()
        {
            if (Input.GetMouseButtonDown(1)) _isChoosing = false;
        }

        [Inject]
        public void Construct(AbilitiesStorage abilitiesStorage, EventBus.Game.EventBus eventBus,
            TurnPipeline turnPipeline)
        {
            _abilitiesStorage = abilitiesStorage;
            _eventBus = eventBus;
            _turnPipeline = turnPipeline;
        }

        public void SetHero(ActorData hero)
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
            print(abilityConfig.ID);
            _turnPipeline.Run();
            ServiceLocator.Instance.BattleController.NextTurn();
            return;
            if (abilityConfig.TargetType == AbilityTargetType.Self)
            {
                abilityConfig.Process(_eventBus, _hero, _hero);
                _turnPipeline.Run();
                return;
            }

            _isChoosing = true;
        }

        public void Clear()
        {
            while (spellsViewParent.transform.childCount > 0)
                DestroyImmediate(spellsViewParent.transform.GetChild(0).gameObject);
        }
    }
}