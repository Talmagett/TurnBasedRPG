using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace UI.Views.TabMenu.Inventory
{
    public class ItemView : MonoBehaviour
    {
        public event Action OnPressed
        {
            add
            {
                button.onClick.AddListener(()=>value());
            }
            remove
            {
                button.onClick.RemoveListener(()=>value());
            }
        }
        
        [SerializeField] private Button button;
        [SerializeField] private Image image;
        
        public void SetIcon(Sprite icon)
        {
            image.sprite = icon;
        }
    }
}