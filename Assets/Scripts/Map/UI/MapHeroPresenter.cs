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
                _mapHeroViews[index].SetIcon(playerCharacter.GetConfig().Icon);
                _mapHeroViews[index]
                    .SetHealth((float)playerCharacter.Stats.Health.Value / playerCharacter.Stats.MaxHealth.Value);
                _mapHeroViews[index]
                    .SetMana((float)playerCharacter.Stats.Mana.Value / playerCharacter.Stats.MaxMana.Value);
                index++;
            }
        }
    }
}