using System;
using System.Linq;
using Battle.Actors;
using Battle.Characters;
using Configs.Abilities;
using Configs.Character;
using Configs.Enums;
using Game.Control;
using PrimeTween;
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
        private AbilityConfig _castingAbility;
        private CursorController _cursorController;

        private ActorData _hero;
        private bool _isChoosing;

        private void Update()
        {
            if (!_isChoosing)
                return;

            if (Input.GetMouseButtonDown(1)) _isChoosing = false;
            if (!Input.GetMouseButtonDown(0)) return;

            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (!Physics.Raycast(ray, out var hit)) return;

            if (!hit.transform.TryGetComponent(out ActorData actorData)) return;

            switch (_castingAbility.TargetType)
            {
                case AbilityTargetType.Ally when actorData.Owner == _hero.Owner:
                case AbilityTargetType.Enemy when actorData.Owner != _hero.Owner:
                case AbilityTargetType.Any:
                    CastAbility(_castingAbility, actorData);
                    break;
            }
        }

        [Inject]
        public void Construct(AbilitiesStorage abilitiesStorage, CursorController cursorController)
        {
            _abilitiesStorage = abilitiesStorage;
            _cursorController = cursorController;
        }

        /*private void OnEnable()
        {
            ServiceLocator.Instance.BattleController.BattleQueue.OnCharacterChanged += OnCharacterChanged;
        }

        private void OnDisable()
        {
            ServiceLocator.Instance.BattleController.BattleQueue.OnCharacterChanged -= OnCharacterChanged;
        }*/

        private void OnCharacterChanged(ActorData unit)
        {
            Clear();
            if (unit.Owner == Owner.Player)
                SetHero(unit);
            var targetScale = unit.Owner == Owner.Player ? Vector3.one : Vector3.zero;

            if (targetScale == transform.localScale)
                return;

            Tween.Scale(transform, targetScale, 0.2f);
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
            _castingAbility = abilityConfig;

            if (_castingAbility.TargetType == AbilityTargetType.Self)
            {
                CastAbility(_castingAbility, _hero);
                _cursorController.SetCursor(CursorType.None);
                return;
            }

            switch (abilityConfig.TargetType)
            {
                case AbilityTargetType.Ally:
                    _cursorController.SetCursor(CursorType.Ally);
                    break;
                case AbilityTargetType.Enemy:
                    _cursorController.SetCursor(CursorType.Enemy);
                    break;
                case AbilityTargetType.Any:
                    _cursorController.SetCursor(CursorType.Any);
                    break;
            }

            _isChoosing = true;
        }

        private void CastAbility(AbilityConfig abilityConfig, ActorData actorData)
        {
            abilityConfig.GetAbilityClone(_hero, actorData);
            _cursorController.SetCursor(CursorType.None);
        }

        private void Clear()
        {
            while (spellsViewParent.transform.childCount > 0)
                DestroyImmediate(spellsViewParent.transform.GetChild(0).gameObject);
        }
    }
}