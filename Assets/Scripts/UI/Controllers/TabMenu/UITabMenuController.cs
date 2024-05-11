using Game.Heroes;
using UI.Presenters;
using UI.Views.TabMenu;
using UnityEngine;
using Zenject;

namespace UI.Controllers.TabMenu
{
    public class UITabMenuController : MonoBehaviour
    {
        [SerializeField] private HeroDataView heroDataView;
        [SerializeField] private UIInventoryController uiInventoryController;

        private HeroParty _heroParty;

        private PlayerInputActions _inputActions;

        [Inject]
        public void Ctor(HeroParty heroParty, PlayerInputActions inputActions)
        {
            _heroParty = heroParty;
            _inputActions = inputActions;
        }

        public void ShowCharacterPanel(int index = 0)
        {
            heroDataView.gameObject.SetActive(true);
            _inputActions.Map.Disable();

            var hero = _heroParty.HeroDataArray[index];

            var characterStatObserver = new CharacterStatObserver(heroDataView.CharacterStatsView, hero);
            var characterDataPresenter = new CharacterDataPresenter(heroDataView.HeroPersonalDataView, hero);
        }

        public void HideCharacterPanel()
        {
            _inputActions.Map.Enable();
        }

        public void ShowInventoryPanel()
        {
            _inputActions.Map.Disable();
            uiInventoryController.Show();
        }
    }
}