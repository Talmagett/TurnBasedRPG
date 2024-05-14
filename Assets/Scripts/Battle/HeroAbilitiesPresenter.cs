using System;
using System.Linq;
using Character;
using Character.Components;
using Configs.Abilities;
using Configs.Character;
using Configs.Enums;
using EventBus.Events;
using Game.Control;
using Modules.Entities.Scripts;
using PrimeTween;
using UI;
using UnityEngine;
using Zenject;

namespace Battle
{
    public class HeroAbilitiesPresenter : MonoBehaviour
    {
        [SerializeField] private Transform spellsViewParent;
        [SerializeField] private BattleAbilityView battleAbilityView;

        private AbilityConfig _castingAbility;
        private CursorController _cursorController;

        private IEntity _hero;
        private bool _isChoosing;

        private void Update()
        {
            if (!_isChoosing)
                return;

            if (Input.GetMouseButtonDown(1)) _isChoosing = false;
            if (!Input.GetMouseButtonDown(0)) return;

            var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (!Physics.Raycast(ray, out var hit)) return;

            if (!hit.transform.TryGetComponent(out CharacterEntity actorData)) return;

            switch (_castingAbility.TargetType)
            {
                case AbilityTargetType.Ally
                    when actorData.Get<Component_Owner>().owner == _hero.Get<Component_Owner>().owner:
                case AbilityTargetType.Enemy
                    when actorData.Get<Component_Owner>().owner != _hero.Get<Component_Owner>().owner:
                case AbilityTargetType.Any:
                    CastAbility(_castingAbility, actorData);
                    break;
            }
        }

        private void OnEnable()
        {
            EventBus.EventBus.Subscribe<CharacterTurnEvent>(OnCharacterChanged);
        }

        private void OnDisable()
        {
            EventBus.EventBus.Unsubscribe<CharacterTurnEvent>(OnCharacterChanged);
        }

        [Inject]
        public void Construct(CursorController cursorController)
        {
            _cursorController = cursorController;
            Hide();
        }

        private void OnCharacterChanged(CharacterTurnEvent evt)
        {
            Clear();

            var owner = evt.Entity.Get<Component_Owner>().owner;
            if (owner.Value != Owner.Player)
            {
                Hide();
            }
            else
            {
                Show();
                SetHero(evt.Entity);
            }
        }

        private void Show()
        {
            Clear();
            Tween.Scale(transform, Vector3.one, 0.2f);
        }

        private void Hide()
        {
            Tween.Scale(transform, Vector3.zero, 0.2f);
        }

        private void SetHero(IEntity hero)
        {
            _isChoosing = false;
            _hero = hero;
            var heroAbilities = _hero.Get<HeroCharacterConfig>().Abilities;
            if (heroAbilities == null)
                throw new NullReferenceException($"No ability pack with this id {_hero.Get<Component_ID>()}");

            foreach (var ability in heroAbilities)
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
                case AbilityTargetType.Self:
                    CastAbility(_castingAbility, _hero);
                    _cursorController.SetCursor(CursorType.None);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            _isChoosing = true;
        }

        private void CastAbility(AbilityConfig abilityConfig, IEntity characterEntity)
        {
            _isChoosing = false;
            EventBus.EventBus.RaiseEvent(new CastAbilityEvent(_hero, characterEntity, abilityConfig));
            _cursorController.SetCursor(CursorType.None);
            Hide();
        }

        private void Clear()
        {
            while (spellsViewParent.transform.childCount > 0)
                DestroyImmediate(spellsViewParent.transform.GetChild(0).gameObject);
        }
    }
}