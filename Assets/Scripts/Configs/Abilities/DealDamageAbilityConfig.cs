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
    [CreateAssetMenu(fileName = "New Ability", menuName = "SO/Ability/DealDamageAbility")]
    public class DealDamageAbilityConfig : AbilityConfig
    {
        [field: SerializeField] public ParticleSystem HitEffect { get; private set; }
        [field: SerializeField] public BaseValue BonusDamage { get; private set; }
        [field: SerializeField] public StatMultiplier StatMultiplier { get; private set; }

        public override IAbility GetAbilityClone(ActorData source, ActorData target) =>
            new DealDamageAbility(source, target, this);
    }

    public class DealDamageAbility : IAbility
    {
        private readonly DealDamageAbilityConfig _config;
        private readonly ActorData _source;
        private readonly ActorData _target;

        public DealDamageAbility(ActorData source, ActorData target, DealDamageAbilityConfig config)
        {
            _source = source;
            _target = target;
            _config = config;
            Init();
        }

        private void Init()
        {
            _source.AnimatorDispatcher.AnimationEvent += Melee;
            _source.Animator.SetTrigger(AnimationKey.GetAnimation(_config.AnimationKey));
        }
        
        private void Melee()
        {
            var attackPowerStat = _source.SharedStats.GetStat(_config.StatMultiplier.Stat);
            var damage = (int)(_config.BonusDamage.Value + _config.StatMultiplier.Multiplier * attackPowerStat.Value);
            ServiceLocator.Instance.EventBus.RaiseEvent(new DealDamageEvent(_source, _target, damage));
            ServiceLocator.Instance.EventBus.RaiseEvent(new VisualParticleEvent(_target, _config.HitEffect));

            _source.AnimatorDispatcher.AnimationEvent -= Melee;
            _source.ConsumeAction();
            ServiceLocator.Instance.BattleController.Run();
        }
    }
}