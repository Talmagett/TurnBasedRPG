using System;
using Game.Heroes;
using UI.Views.TabMenu.Character;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace UI.Controllers.TabMenu
{
    public class HeroesListController : MonoBehaviour
    {
        [SerializeField] private SelectHeroView selectHeroView;
        [SerializeField] private Transform parent;
        
        public void Create(Sprite icon, Action action)
        {
            var view = Instantiate(selectHeroView, parent);
            view.SetIcon(icon, action);
        }
    }
}