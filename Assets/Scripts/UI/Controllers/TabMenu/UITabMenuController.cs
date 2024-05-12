using Game.Heroes;
using Sirenix.OdinInspector;
using UI.Presenters;
using UI.Views.TabMenu;
using UnityEngine;
using Zenject;

namespace UI.Controllers.TabMenu
{
    public class UITabMenuController : MonoBehaviour
    {
        [SerializeField] private HeroesListController heroesListController;
        //[SerializeField] private HeroDataView heroDataView;
        [SerializeField] private UIInventoryController uiInventoryController;
        [SerializeField] private UIEquipmentController uiEquipmentController;
        
        private HeroParty _heroParty;
        private PlayerInputActions _inputActions;

        [Inject]
        public void Ctor(HeroParty heroParty, PlayerInputActions inputActions)
        {
            _heroParty = heroParty;
            _inputActions = inputActions;
        }

        // from outside
        public void ShowCharactersList()
        {
            _inputActions.Map.Disable();

            for (int i = 0; i < _heroParty.HeroDataArray.Length; i++)
            {
                var index = i;
                heroesListController.Show(_heroParty.HeroDataArray[i].CharacterConfig.Icon,()=>ShowCharacterPanel(index));
            }
        }
        
        public void ShowCharacterPanel(int index)
        {
            uiEquipmentController.SetCharacterIndex();
            /*
            heroDataView.gameObject.SetActive(true);

            var hero = _heroParty.HeroDataArray[index];

            var characterStatObserver = new CharacterStatObserver(heroDataView.CharacterStatsView, hero);
            var characterDataPresenter = new CharacterDataPresenter(heroDataView.HeroPersonalDataView, hero);*/
        }

        [Button]
        public void ShowEquipment()
        {
            uiEquipmentController.Show();
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