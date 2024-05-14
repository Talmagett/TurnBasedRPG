using Atomic.Elements;
using Game.Gameplay.Characters.Scripts;
using Game.Gameplay.Characters.Scripts.Components;
using Game.UI.Scripts.Battle.View;
using UnityEngine;

namespace Game.UI.Scripts.Battle
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
            turnWidget.SetTurn(turn.ToString(), turn == 0);
        }
    }
}