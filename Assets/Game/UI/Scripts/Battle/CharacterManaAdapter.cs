using Atomic.Elements;
using Character;
using Character.Components;
using UI.Battle.View;
using UnityEngine;

namespace UI.Battle
{
    public sealed class CharacterManaAdapter : MonoBehaviour
    {
        [SerializeField] private ResourceBar resourceBar;
        
        private CharacterEntity _entity;

        private AtomicVariable<int> _mana;
        private AtomicVariable<int> _maxMana;

        private void Awake()
        {
            _entity = GetComponentInParent<CharacterEntity>();
        }

        private void Start()
        {
            _mana = _entity.Get<Component_Mana>().mana;
            _maxMana = _entity.Get<Component_Mana>().maxMana;
            _mana.Subscribe(UpdateText);
            UpdateText(_mana.Value);
        }

        private void OnDestroy()
        {
            _mana.Unsubscribe(UpdateText);
        }

        private void UpdateText(int value)
        {
            if (value < 0) value = 0;
            resourceBar.SetFill((float)value / _maxMana.Value);
            resourceBar.SetText($"{value}/{_maxMana.Value}");
        }
    }
}