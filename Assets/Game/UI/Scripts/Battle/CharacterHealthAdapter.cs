using Atomic.Elements;
using Character;
using Character.Components;
using UI.Battle.View;
using UnityEngine;

namespace UI.Battle
{
    public sealed class CharacterHealthAdapter : MonoBehaviour
    {
        [SerializeField] private ResourceBar resourceBar;
        private CharacterEntity _entity;

        private AtomicVariable<int> _health;
        private AtomicVariable<int> _maxHealth;

        private void Awake()
        {
            _entity = GetComponentInParent<CharacterEntity>();
        }

        private void Start()
        {
            _health = _entity.Get<Component_Life>().health;
            _maxHealth = _entity.Get<Component_Life>().maxHealth;
            _health.Subscribe(UpdateText);
            UpdateText(_health.Value);
        }

        private void OnDestroy()
        {
            _health.Unsubscribe(UpdateText);
        }

        private void UpdateText(int value)
        {
            if (value < 0) value = 0;
            resourceBar.SetFill((float)value / _maxHealth.Value);
            resourceBar.SetTextWithAnimation($"{value}/{_maxHealth.Value}", 0.2f);
        }
    }
}