using Game.Gameplay.Game.Heroes;
using Game.UI.Scripts.Presenters;
using Game.UI.Scripts.Views.TabMenu;
using UnityEngine;

namespace Game.UI.Scripts.Controllers.TabMenu
{
    public class HeroUIController : MonoBehaviour
    {
        [SerializeField] private HeroPersonalDataView heroPersonalDataView;
        [SerializeField] private CharacterStatsView characterStatsView;
        [SerializeField] private UIEquipmentController equipmentController;

        public void Show(Hero hero)
        {
            gameObject.SetActive(true);
            var characterStatObserver = new CharacterStatObserver(characterStatsView, hero);
            var characterDataPresenter = new CharacterDataPresenter(heroPersonalDataView, hero);
            equipmentController.Setup(hero);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}