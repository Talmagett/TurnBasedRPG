using Configs.Character;
using Game.Heroes;
using UnityEngine;
using Zenject;

namespace UI.Controllers.TabMenu
{
    public class UITabMenuController : MonoBehaviour
    {
        [SerializeField] private HeroesListController heroesListController;
        [SerializeField] private HeroUIController heroUIController;

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
            heroesListController.gameObject.SetActive(true);
            for (var i = 0; i < _heroParty.HeroDataArray.Length; i++)
            {
                var index = i;
                heroesListController.Create(_heroParty.HeroDataArray[index].Get<CharacterConfig>().Icon,
                    () => ShowCharacterPanel(_heroParty.HeroDataArray[index]));
            }
        }

        private void ShowCharacterPanel(Hero hero)
        {
            heroUIController.Show(hero);
            uiInventoryController.Show();
        }

        public void HideCharacterPanel()
        {
            _inputActions.Map.Enable();
        }
    }
}