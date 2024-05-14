using System;
using Game.UI.Scripts.Views.TabMenu.Character;
using UnityEngine;

namespace Game.UI.Scripts.Controllers.TabMenu
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

        public void Clear()
        {
            while (parent.childCount>0)
            {
                DestroyImmediate(parent.GetChild(0).gameObject);
            }
        }
    }
}