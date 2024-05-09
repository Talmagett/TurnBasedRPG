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
            
            _source.AnimatorDispatcher.AnimationEvent += Hit;
            _source.Animator.SetTrigger(AnimationKey.GetAnimation(_config.AnimationKey));
        }

        private void Hit()
        {
            _source.AnimatorDispatcher.AnimationEvent -= Hit;
            foreach (var effect in _config.Effects)
            {
                effect.Source = _source;
                effect.Target = _target;
                EventBus.EventBus.RaiseEvent(effect);
            }
            
            EventBus.EventBus.RaiseEvent(new FinishTurnEvent(_source));
        }
    }
}