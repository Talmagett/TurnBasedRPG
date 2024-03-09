using System;
using Map.Characters;
using UnityEngine;
using UniRx;

namespace Map.UI
{
    public class MapHeroPresenter : MonoBehaviour
    {
        [SerializeField] private MapHeroView mapHeroViewPrefab;
        [SerializeField] private Transform parent;
        [SerializeField] private PartyController partyController;

        private MapHeroView[] _mapHeroViews;
        private void Start()
        {
            _mapHeroViews = new MapHeroView[partyController.GetHeroes().Length];
            int index = 0;
            foreach (var playerCharacter in partyController.GetHeroes())
            {
                _mapHeroViews[index] = Instantiate(mapHeroViewPrefab, parent);
                _mapHeroViews[index].SetCharacterIcon(playerCharacter.GetConfig().Icon);
                _mapHeroViews[index].SetCharacterHealth((float)playerCharacter.Health.Value/playerCharacter.MaxHealth.Value);
                index++;
            }
        }
    }
}