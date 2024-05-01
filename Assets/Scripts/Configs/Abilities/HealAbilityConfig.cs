using System;
using Battle.Actors;
using Battle.EventBus.Game;
using Battle.EventBus.Game.Events;
using Configs.Abilities.Attributes;
using Configs.Character;
using Configs.Enums;
using Game;
using UnityEngine;

namespace Configs.Abilities
{
    [Serializable]
    [CreateAssetMenu(fileName = "New Ability", menuName = "SO/Ability/DealDamageAbility")]
    public class HealAbilityConfig : AbilityConfig
    {
        [field: SerializeField] public ParticleSystem HealEffect { get; private set; }
        [field: SerializeField] public BodyParts.Key HealEffectPoint { get; private set; }
        [field: SerializeField] public AbilityPowerValue HealAmount { get; private set; }

        public override IAbility GetAbilityClone(ActorData source, ActorData target) =>
            new HealAbility(source, target, this);
    }

    public class HealAbility : IAbility
    {
        private readonly HealAbilityConfig _config;
        private readonly ActorData _source;
        private readonly ActorData _target;

        public HealAbility(ActorData source, ActorData target, HealAbilityConfig config)
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
            var statValue = _source.SharedStats.GetStat(_config.HealAmount.Stat);
            var damage = (int)(_config.HealAmount.BonusValue + _config.HealAmount.StatMultiplier * statValue.Value);
            
            EventBus.RaiseEvent(new DealDamageEvent(_source, _target, damage));
            var effectPoint = _target.BodyParts.GetPoint(_config.HealEffectPoint);
            EventBus.RaiseEvent(new VisualParticleEvent(effectPoint, _config.HealEffect));

            _source.AnimatorDispatcher.AnimationEvent -= Melee;
            _source.ConsumeAction();
            //ServiceLocator.Instance.BattleController.Run();
        }
    }
}