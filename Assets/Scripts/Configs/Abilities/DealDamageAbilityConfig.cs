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
    public class DealDamageAbilityConfig : AbilityConfig
    {
        [field: SerializeField] public ParticleSystem HitEffect { get; private set; }
        [field: SerializeField] public BodyParts.Key HitEffectPoint { get; private set; }
        [field: SerializeField] public AbilityStat DamageAmount { get; private set; }

        public override IAbility GetAbilityClone(ActorData source, ActorData target)
        {
            return new DealDamageAbility(source, target, this);
        }
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
            EventBus.EventBus.RaiseEvent(new ConsumeEnergyEvent(source,config.EnergyCost));
            
            _source.AnimatorDispatcher.AnimationEvent += Melee;
            _source.Animator.SetTrigger(AnimationKey.GetAnimation(_config.AnimationKey));
        }

        private void Melee()
        {
            var statValue = _source.SharedStats.GetStat(_config.DamageAmount.Stat);
            var damage = (int)(_config.DamageAmount.BaseValue + _config.DamageAmount.MultValue * statValue.Value);

            EventBus.EventBus.RaiseEvent(new DealDamageEvent(_source, _target, damage));
            var effectPoint = _target.BodyParts.GetPoint(_config.HitEffectPoint);
            EventBus.EventBus.RaiseEvent(new VisualParticleEvent(effectPoint, _config.HitEffect));

            _source.AnimatorDispatcher.AnimationEvent -= Melee;
            _source.ConsumeAction();

            _source.Deselect();
            EventBus.EventBus.RaiseEvent(new DelayedEvent(new NextTurnEvent(),1f));
        }
    }
}