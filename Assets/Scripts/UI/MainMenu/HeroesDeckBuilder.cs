using System;
using Data;
using UI.Components;
using UnityEngine;

namespace UI.MainMenu
{
    public class HeroesDeckBuilder : MonoBehaviour
    {
        [SerializeField] private Transform parent;
        [SerializeField] private ButtonIconTextUI heroPrefab;
        [SerializeField] private HeroData[] heroesData;
        
        private Party _party;

        private void Start()
        {
            foreach (var item in heroesData)
            {
                var heroButton = Instantiate(heroPrefab, parent);
                heroButton.SetData(item.Icon,item.HeroName,
                    ()=>ChooseHero(item));
            }   
        }

        private void ChooseHero(HeroData heroData)
        {
            _party.PickUnpickHero(heroData);
        }
    }
}