using Atomic.Objects;
using UnityEngine;
using Visual.Presenters;

namespace Visual.UI.TabMenu
{
    public class TabMenuController : MonoBehaviour
    {
        [SerializeField] private HeroDataView heroDataView;
        [SerializeField] private AtomicObject hero;
        
        private void OnEnable()
        {
            UpdateUI();
        }

        private void UpdateUI()
        {
            if (hero is null)
                return;

            var characterStatObserver = new CharacterStatObserver(heroDataView.CharacterStatsView, hero);
            var characterDataPresenter = new CharacterDataPresenter(heroDataView.HeroPersonalDataView, hero);
        }

        private void OnDisable()
        {
            
        }
    }
}