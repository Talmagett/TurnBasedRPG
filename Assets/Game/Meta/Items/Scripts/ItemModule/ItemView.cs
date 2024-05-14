using System;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Meta.Items.Scripts.ItemModule
{
    public class ItemView : MonoBehaviour
    {
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

        public event Action OnPressed;

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