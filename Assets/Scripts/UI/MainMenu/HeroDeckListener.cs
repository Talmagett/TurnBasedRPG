using System;
using System.Collections.Generic;
using Data;
using UI.Components;
using UnityEngine;

namespace UI.MainMenu
{
    public class HeroDeckListener:MonoBehaviour
    {
        //[Inject]
        [SerializeField] private IconTextUI[] deckUI;
        private Party _party;

        private void OnEnable()
        {
            _party.OnHeroesChanged += UpdateVisualDeck;
        }

        private void UpdateVisualDeck(List<HeroData> heroDatas)
        {
            for (int i = 0; i < deckUI.Length; i++)
            {
                if (heroDatas[i] != null)
                    deckUI[i].SetData(heroDatas[i].Icon,heroDatas[i].HeroName);
                else
                    deckUI[i].SetData(null,"");
            }
        }
    }
}