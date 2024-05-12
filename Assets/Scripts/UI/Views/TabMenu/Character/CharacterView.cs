using System;
using UI.Views.Map;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Views.TabMenu.Character
{
    public class CharacterView : MonoBehaviour
    {
        [SerializeField] private Button button;
        [SerializeField] private CharacterIconView characterIconView;

        public void SetIcon(Sprite icon, Action onClick)
        {
            characterIconView.SetIcon(icon);
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(()=>onClick?.Invoke());
        }

        private void OnDestroy()
        {
            button.onClick.RemoveAllListeners();
        }
    }
}