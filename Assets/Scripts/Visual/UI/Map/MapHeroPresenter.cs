using Game.Heroes;
using UnityEngine;
using Zenject;

namespace Visual.UI.Map
{
    public class MapHeroPresenter : MonoBehaviour
    {
        [SerializeField] private HeroView heroViewPrefab;
        [SerializeField] private Transform parent;

        private HeroView[] _mapHeroViews;

        private HeroParty _party;
        [Inject]
        public void CTOR(HeroParty party)
        {
            _party = party;
            Debug.Log(_party.HeroDataArray[0].ID);
        }
        private void Start()
        {
            var index = 0;
            /*foreach (var playerCharacter in partyController.GetHeroes())
            {
                _mapHeroViews[index] = Instantiate(heroViewPrefab, parent);
                _mapHeroViews[index].SetIcon(playerCharacter.characterConfig.Value.Icon);
                _mapHeroViews[index]
                    .SetHealth((float)playerCharacter.stats.Value.health.Value / playerCharacter.stats.Value.maxHealth.Value);
                _mapHeroViews[index]
                    .SetMana((float)playerCharacter.stats.Value.mana.Value / playerCharacter.stats.Value.maxMana.Value);
                index++;
            }*/
        }
    }
}