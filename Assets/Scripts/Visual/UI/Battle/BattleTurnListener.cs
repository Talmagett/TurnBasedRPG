using System;
using Atomic.Elements;
using Battle.Actors;
using Configs.Enums;
using PrimeTween;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Visual.UI.Battle
{
    public class BattleTurnListener : MonoBehaviour
    {
        [SerializeField] private Image iconImage;
        [SerializeField] private TMP_Text turnText;
        
        private ActorData _actorData;
        private AtomicVariable<int> _cooldown;
        
        private void Awake()
        {
            _actorData = GetComponentInParent<ActorData>();
            
            if (!_actorData.TryGet<AtomicVariable<int>>(AtomicPropertyAPI.CooldownKey, out var cooldown)) throw new NullReferenceException("No Cooldown Key");

            _cooldown = cooldown;
            _cooldown.Subscribe(UpdateCooldownText);
            UpdateCooldownText(_cooldown.Value);
        }

        private void OnDestroy()
        {
            _cooldown.Unsubscribe(UpdateCooldownText);
        }

        private void UpdateCooldownText(int turn)
        {
            //TODO: prime tween
            Tween.ShakeLocalRotation(iconImage.transform, Vector3.one, 0.2f).OnComplete(() =>
            {
                turnText.text = turn==0?"":turn.ToString();
                iconImage.color=turn==0?Color.green: Color.white;
            });
        }
    }
}