using Configs;
using Configs.Enums;
using Game.Heroes;
using TMPro;
using UnityEngine;
using Zenject;

namespace Visual.UI.Map
{
    public class MapHeroPresenter : MonoBehaviour
    {
        [SerializeField] private HeroView heroViewPrefab;
        [SerializeField] private Transform parent;

        private HeroParty _party;
        private HeroView[] _mapHeroViews;
        
        [Inject]
        public void Construct(HeroParty party)
        {
            _party = party;
        }
        
        private void Start()
        {
            var index = 0;
            _mapHeroViews = new HeroView[_party.HeroDataArray.Length];
            foreach (var playerCharacter in _party.HeroDataArray)
            {
                _mapHeroViews[index] = Instantiate(heroViewPrefab, parent);
                _mapHeroViews[index].SetIcon(playerCharacter.Icon);
                _mapHeroViews[index]
                    .SetHealth(playerCharacter.Stats.GetStat(StatKey.Health) / playerCharacter.Stats.GetStat(StatKey.MaxHealth));
                _mapHeroViews[index]
                    .SetMana(playerCharacter.Stats.GetStat(StatKey.Mana) / playerCharacter.Stats.GetStat(StatKey.MaxMana));
                index++;
            }
        }
    }
}