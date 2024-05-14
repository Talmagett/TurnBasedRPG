using Atomic.Elements;
using Character;
using Character.Components;
using UI.Battle.View;
using UnityEngine;

namespace UI.Battle
{
    public class CharacterTurnAdapter : MonoBehaviour
    {
        [SerializeField] private TurnWidget turnWidget;

        private CharacterEntity _characterEntity;
        
        private AtomicVariable<int> _energy;

        private void Start()
        {
            _characterEntity = GetComponentInParent<CharacterEntity>();

            _energy = _characterEntity.Get<Component_Turn>().energy;
            UpdateCooldownText(_energy.Value);
            _energy.Subscribe(UpdateCooldownText);
        }

        private void OnDestroy()
        {
            _energy.Unsubscribe(UpdateCooldownText);
        }

        private void UpdateCooldownText(int turn)
        {
            turnWidget.SetTurn(turn.ToString(),turn==0);
        }
    }
}