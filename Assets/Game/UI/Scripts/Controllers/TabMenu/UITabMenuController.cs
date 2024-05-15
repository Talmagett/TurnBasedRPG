using Game.Gameplay.Characters.Scripts.SO;
using Game.Gameplay.Game.Heroes;
using UnityEngine;
using Zenject;

namespace Game.UI.Scripts.Controllers.TabMenu
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
            heroesListController.Clear();
            heroesListController.gameObject.SetActive(true);
            
            for (var i = 0; i < _heroParty.HeroDataArray.Length; i++)
            {
                var index = i;
                heroesListController.Create(_heroParty.HeroDataArray[index].Get<CharacterConfig>().Icon,
                    () => ShowCharacterPanel(_heroParty.HeroDataArray[index]));
            }
        }

        public void HideCharactersList()
        {
            heroUIController.Hide();
            _inputActions.Map.Enable();
            heroesListController.gameObject.SetActive(false);
        }

        private void ShowCharacterPanel(Hero hero)
        {
            heroUIController.Show(hero);
            uiInventoryController.Show();
        }
    }
}