using System;
using Battle.Actors;
using Battle.Actors.Model;
using Configs;
using Configs.Enums;
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

        private ActorData _actorData;
        private Attack _attack;
        private SharedCharacterStats _stats;

        private void Start()
        {
            _actorData = GetComponentInParent<ActorData>();

            if (!_actorData.TryGet(AtomicAPI.Attack, out _attack))
                throw new NullReferenceException("No Cooldown Key");
            _attack.energy.Subscribe(UpdateCooldownText);
            UpdateCooldownText(_attack.energy.Value);
        }

        private void OnDestroy()
        {
            _attack.energy.Unsubscribe(UpdateCooldownText);
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