using Atomic.Elements;
using Character;
using Character.Components;
using PrimeTween;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Battle
{
    public class BattleActorAdapter : MonoBehaviour
    {
        [SerializeField] private Image iconImage;
        [SerializeField] private TMP_Text turnText;

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
            //TODO: prime tween
            Tween.ShakeLocalRotation(iconImage.transform, Vector3.forward * 90, 0.3f).OnComplete(() =>
            {
                turnText.text = turn == 0 ? "" : turn.ToString();
                iconImage.color = turn == 0 ? Color.green : Color.white;
            });
        }
    }
}