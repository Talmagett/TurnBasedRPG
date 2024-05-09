using System;
using Game.Heroes;
using UnityEngine;
using Visual.Presenters;
using Visual.UI.TabMenu;
using Zenject;

namespace UI.Controllers.TabMenu
{
    public class UITabMenuController : MonoBehaviour
    {
        [SerializeField] private HeroDataView heroDataView;

        private HeroParty _heroParty;
        
        private PlayerInputActions _inputActions;

        [Inject]
        public void Ctor(HeroParty heroParty,PlayerInputActions inputActions)
        {
            _heroParty = heroParty;
            _inputActions = inputActions;
        }

        private void OnEnable()
        {
            _inputActions.Map.Disable();
        }

        private void OnDisable()
        {
            _inputActions.Map.Enable();
        }

        public void ShowCharacterPanel(int index=0)
        {
            heroDataView.gameObject.SetActive(true);
            var hero = _heroParty.HeroDataArray[index];

            var characterStatObserver = new CharacterStatObserver(heroDataView.CharacterStatsView, hero);
            var characterDataPresenter = new CharacterDataPresenter(heroDataView.HeroPersonalDataView, hero);
        }
    }
}