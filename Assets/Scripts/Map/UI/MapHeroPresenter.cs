using Map.Characters;
using UnityEngine;

namespace Map.UI
{
    public class MapHeroPresenter : MonoBehaviour
    {
        [SerializeField] private HeroView heroViewPrefab;
        [SerializeField] private Transform parent;
        [SerializeField] private PartyController partyController;

        private HeroView[] _mapHeroViews;

        private void Start()
        {
            _mapHeroViews = new HeroView[partyController.GetHeroes().Length];
            var index = 0;
            foreach (var playerCharacter in partyController.GetHeroes())
            {
                _mapHeroViews[index] = Instantiate(heroViewPrefab, parent);
                _mapHeroViews[index].SetIcon(playerCharacter.characterConfig.Value.Icon);
                _mapHeroViews[index]
                    .SetHealth((float)playerCharacter.stats.Value.health.Value / playerCharacter.stats.Value.maxHealth.Value);
                _mapHeroViews[index]
                    .SetMana((float)playerCharacter.stats.Value.mana.Value / playerCharacter.stats.Value.maxMana.Value);
                index++;
            }
        }
    }
}