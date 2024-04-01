using System;
using Battle.Actors;
using Battle.EventBus.Game.Events;
using Configs.Abilities.Attributes;
using Configs.Enums;
using Game;
using UnityEngine;

namespace Configs.Abilities
{
    [Serializable]
    [CreateAssetMenu(fileName = "New Ability", menuName = "SO/Ability/DealDamageAbility", order = 0)]
    public class DealDamageAbilityConfig : AbilityConfig
    {
        [field: SerializeField] public ParticleSystem HitEffect { get; private set; }
        [field: SerializeField] public BaseValue BonusDamage { get; private set; }
        [field: SerializeField] public StatMultiplier StatMultiplier { get; private set; }
    }
    
    public class DealDamageAbility
    {
        private readonly ActorData _source;
        private readonly ActorData _target;
        private readonly DealDamageAbilityConfig _config;

        public DealDamageAbility(ActorData source, ActorData target, DealDamageAbilityConfig config)
        {
            _source = source;
            _target = target;
            _config = config;
            MeleeAttackAsync();
        }

        private void MeleeAttackAsync()
        {
            _source.AnimatorDispatcher.AnimationEvent += Melee;
            _source.Animator.SetTrigger(AnimationKey.GetAnimation(AnimationKey.Animation.Attack));
        }

        private void Melee()
        {
            var attackPowerStat = _source.SharedStats.GetStat(_config.StatMultiplier.Stat);
            //var damage = (int)(bonusDamage.Value + attackPowerMultiplier.Multiplier * attackPowerStat);
            var damage = 20;
            ServiceLocator.Instance.EventBus.RaiseEvent(new DealDamageEvent(_source, _target, damage));
            ServiceLocator.Instance.EventBus.RaiseEvent(new VisualParticleEvent(_target, _config.HitEffect));

            _source.AnimatorDispatcher.AnimationEvent -= Melee;
            ServiceLocator.Instance.BattleController.Run();
            ServiceLocator.Instance.BattleController.NextTurn();
        }
    }
}