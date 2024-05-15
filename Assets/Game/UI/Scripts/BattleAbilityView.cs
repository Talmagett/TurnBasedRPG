using System;
using Game.Gameplay.Abilities.Scripts;
using Game.UI.Scripts.Views.Map;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI.Scripts
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