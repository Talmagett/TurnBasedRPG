using System;
using Configs.Abilities;
using UI.Views.Map;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class BattleAbilityView : MonoBehaviour
    {
        public CharacterIconView CharacterIconView;

        [SerializeField] private Button button;

        public AbilityConfig AbilityConfig { get; set; }

        public void Start()
        {
            button.onClick.AddListener(() => OnClicked?.Invoke(AbilityConfig));
        }

        public void OnDestroy()
        {
            button.onClick.RemoveAllListeners();
            OnClicked = null;
        }

        public event Action<AbilityConfig> OnClicked;
    }
}