using Atomic.Elements;
using Character;
using Character.Components;
using PrimeTween;
using TMPro;
using UnityEngine;

namespace UI.Battle.UI
{
    public sealed class TextWidgetHealthAdapter : MonoBehaviour
    {
        [SerializeField] private TMP_Text healthText;
        [SerializeField] private CharacterEntity entity;

        private AtomicVariable<int> _health;

        private void Start()
        {
            _health = entity.Get<Component_Life>().health;
            _health.Subscribe(UpdateHealthText);
            UpdateHealthText(_health.Value);
        }

        private void OnDestroy()
        {
            _health.Unsubscribe(UpdateHealthText);
        }

        private void UpdateHealthText(int value)
        {
            if (value <= 0) return;
            Tween.ShakeLocalRotation(healthText.transform, Vector3.one * 30, 0.2f).OnComplete(() =>
            {
                healthText.text = value.ToString();
            });
        }
    }
}