using System;
using UnityEngine;
using UnityEngine.UI;

namespace Modules.Items.Scripts.ItemModule
{
    public class ItemView : MonoBehaviour
    {
        public event Action OnPressed;
        
        [SerializeField] private Button button;
        [SerializeField] private Image image;

        private void OnEnable()
        {
            button.onClick.AddListener(Invoke);
        }

        private void OnDisable()
        {
            button.onClick.RemoveListener(Invoke);
        }

        private void Invoke()
        {
            OnPressed?.Invoke();
        }

        public void SetIcon(Sprite icon)
        {
            image.sprite = icon;
        }
    }
}