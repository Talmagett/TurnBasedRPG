using System;
using Battle.Actors;
using Configs.Abilities.Attributes;
using Configs.Character;
using Configs.Enums;
using EventBus.Events;
using PrimeTween;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Configs.Abilities
{
    [Serializable]
    [CreateAssetMenu(fileName = "New Ability", menuName = "SO/Ability/ProjectileShootAbility")]
    public class ProjectileShootAbilityConfig : AbilityConfig
    {
        [field: SerializeField] public GameObject Projectile { get; private set; }
        [field: SerializeField] public BodyParts.Key ProjectileShootPoint { get; private set; }
        [field: SerializeField] public BodyParts.Key HitEffectPoint { get; private set; }

        public override IAbility GetAbilityClone(ActorData source, ActorData target)
        {
            return new ProjectileShootAbility(source, target, this);
        }
    }

    public class ProjectileShootAbility : IAbility
    {
        private readonly ProjectileShootAbilityConfig _config;
        private readonly ActorData _source;
        private readonly ActorData _target;

        public ProjectileShootAbility(ActorData source, ActorData target, ProjectileShootAbilityConfig config)
        {
            _source = source;
            _target = target;
            _config = config;
            EventBus.EventBus.RaiseEvent(new ConsumeEnergyEvent(source,config.EnergyCost));
            
            _source.AnimatorDispatcher.AnimationEvent += Shoot;
            _source.Animator.SetTrigger(AnimationKey.GetAnimation(_config.AnimationKey));
        }

        private void Shoot()
        {
            var shootPoint = _source.BodyParts.GetPoint(_config.ProjectileShootPoint);
            var effectPoint = _target.BodyParts.GetPoint(_config.HitEffectPoint);

            var projectile = Object.Instantiate(_config.Projectile, shootPoint.position, Quaternion.identity);
            projectile.transform.LookAt(_target.transform.position);
            Tween.Position(projectile.transform, effectPoint.position, 0.7f, Ease.InSine).OnComplete(() =>
            {
                Object.Destroy(projectile);
                OnHit();
            });
        }
            
        private void OnHit()
        {
            _source.AnimatorDispatcher.AnimationEvent -= Shoot;
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