using System;
using Game.UI.Scripts.Views.Map;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI.Scripts.Views.TabMenu.Character
{
    public class SelectHeroView : MonoBehaviour
    {
        [SerializeField] private Button button;
        [SerializeField] private CharacterIconView characterIconView;
        [SerializeField] private TMP_Text heroNameText;
        
        private void OnDestroy()
        {
            button.onClick.RemoveAllListeners();
        }

        public void SetIcon(Sprite icon, Action onClick)
        {
            characterIconView.SetIcon(icon);
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(() => onClick?.Invoke());
        }

        public void SetName(string heroName)
        {
            heroNameText.text = heroName;
        }
    }
}