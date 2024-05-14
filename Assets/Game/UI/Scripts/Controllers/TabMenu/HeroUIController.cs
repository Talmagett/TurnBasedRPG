using Game.Heroes;
using UI.Presenters;
using UI.Views.TabMenu;
using UnityEngine;
using UnityEngine.Serialization;

namespace UI.Controllers.TabMenu
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