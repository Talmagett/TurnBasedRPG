using System;
using Atomic.Elements;
using Battle.Actors;
using Configs;
using Configs.Enums;
using PrimeTween;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Visual.UI.Battle
{
    public class BattleActorAdapter : MonoBehaviour
    {
        [SerializeField] private Image iconImage;
        [SerializeField] private TMP_Text turnText;
        [SerializeField] private TMP_Text healthText;

        private ActorData _actorData;
        private AtomicVariable<int> _cooldown;
        private SharedCharacterStats _stats;

        private void Start()
        {
            _actorData = GetComponentInParent<ActorData>();

            if (!_actorData.TryGet(AtomicPropertyAPI.CooldownKey, out _cooldown))
                throw new NullReferenceException("No Cooldown Key");
            if (!_actorData.TryGet(AtomicPropertyAPI.StatsKey, out _stats))
                throw new NullReferenceException("No Stats Key");
            _cooldown.Subscribe(UpdateCooldownText);
            _stats.GetStat(StatKey.Health).Subscribe(UpdateHealthText);
            UpdateCooldownText(_cooldown.Value);
            UpdateHealthText(_stats.GetStat(StatKey.Health).Value);
        }

        private void OnDestroy()
        {
            _cooldown.Unsubscribe(UpdateCooldownText);
            _stats.GetStat(StatKey.Health).Unsubscribe(UpdateHealthText);
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

        private void UpdateHealthText(float value)
        {
            if (value <= 0) return;
            Tween.ShakeLocalRotation(healthText.transform, Vector3.one * 30, 0.2f).OnComplete(() =>
            {
                healthText.text = value.ToString();
            });
        }
    }
}