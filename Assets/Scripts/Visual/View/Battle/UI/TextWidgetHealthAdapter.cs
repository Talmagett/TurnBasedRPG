using System;
using Battle.Actors;
using Configs;
using Configs.Enums;
using PrimeTween;
using TMPro;
using UnityEngine;

namespace Visual.UI.Battle.UI
{
    public sealed class TextWidgetHealthAdapter : MonoBehaviour
    {
        [SerializeField] private TMP_Text healthText;
        [SerializeField] private ActorData entity;
        private SharedCharacterStats _stats;


        private void Start()
        {
            if (!entity.TryGet(AtomicAPI.SharedStats, out _stats))
                throw new NullReferenceException("No Stats Key");
            _stats.GetStat(StatKey.Health).Subscribe(UpdateHealthText);
            UpdateHealthText(_stats.GetStat(StatKey.Health).Value);
        }

        private void OnDestroy()
        {
            _stats.GetStat(StatKey.Health).Unsubscribe(UpdateHealthText);
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

