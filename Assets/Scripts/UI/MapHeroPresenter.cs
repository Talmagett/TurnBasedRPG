using Configs.Enums;
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

        private void Start()
        {
            var index = 0;
            _mapHeroViews = new HeroView[_party.HeroDataArray.Length];
            foreach (var playerCharacter in _party.HeroDataArray)
            {
                _mapHeroViews[index] = Instantiate(heroViewPrefab, parent);
                _mapHeroViews[index].SetIcon(playerCharacter.CharacterConfig.Icon);
                _mapHeroViews[index]
                    .SetHealth(playerCharacter.Stats.GetStat(StatKey.Health).Value /
                               playerCharacter.Stats.GetStat(StatKey.MaxHealth).Value);
                _mapHeroViews[index]
                    .SetMana(playerCharacter.Stats.GetStat(StatKey.Mana).Value /
                             playerCharacter.Stats.GetStat(StatKey.MaxMana).Value);
                index++;
            }
        }

        [Inject]
        public void Construct(HeroParty party)
        {
            _party = party;
        }
    }
}