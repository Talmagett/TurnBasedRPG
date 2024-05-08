using System;
using Battle.Actors;
using Configs.Abilities.Attributes;
using Configs.Character;
using Configs.Enums;
using EventBus.Events;
using UnityEngine;

namespace Configs.Abilities
{
    [Serializable]
    [CreateAssetMenu(fileName = "New Ability", menuName = "SO/Ability/DealDamageAbility")]
    public class HealAbilityConfig : AbilityConfig
    {
        [field: SerializeField] public ParticleSystem HealEffect { get; private set; }
        [field: SerializeField] public BodyParts.Key HealEffectPoint { get; private set; }
        [field: SerializeField] public AbilityStat HealAmount { get; private set; }

        public override IAbility GetAbilityClone(ActorData source, ActorData target)
        {
            return new HealAbility(source, target, this);
        }
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
            EventBus.EventBus.RaiseEvent(new ConsumeEnergyEvent(source,config.EnergyCost));
            
            _source.AnimatorDispatcher.AnimationEvent += Heal;
            _source.Animator.SetTrigger(AnimationKey.GetAnimation(_config.AnimationKey));
        }

        private void Heal()
        {
            var statValue = _source.SharedStats.GetStat(_config.HealAmount.Stat);
            var damage = (int)(_config.HealAmount.BaseValue + _config.HealAmount.MultValue * statValue.Value);

            EventBus.EventBus.RaiseEvent(new DealDamageEvent(_source, _target, -damage));
            var effectPoint = _target.BodyParts.GetPoint(_config.HealEffectPoint);
            EventBus.EventBus.RaiseEvent(new VisualParticleEvent(effectPoint, _config.HealEffect));

            _source.AnimatorDispatcher.AnimationEvent -= Heal;
            _source.ConsumeAction();
            
            _source.Deselect();
            EventBus.EventBus.RaiseEvent(new DelayedEvent(new NextTurnEvent(),1f));
        }
    }
}