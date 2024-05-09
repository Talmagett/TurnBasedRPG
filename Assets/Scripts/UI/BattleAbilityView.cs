using System;
using Configs.Abilities;
using UnityEngine;
using UnityEngine.UI;
using Visual.UI.View;

namespace Visual.UI.Battle
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