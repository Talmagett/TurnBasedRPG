using System;
using Game.Heroes;
using UI.Views.TabMenu.Character;
using UnityEngine;
using Zenject;

namespace UI.Controllers.TabMenu
{
    public class HeroesListController : MonoBehaviour
    {
        [SerializeField] private CharacterView characterView;
        [SerializeField] private Transform parent;
        
        public void Show(Sprite icon, Action action)
        {
            var view = Instantiate(characterView, parent);
            view.SetIcon(icon, action);
        }
    }
}