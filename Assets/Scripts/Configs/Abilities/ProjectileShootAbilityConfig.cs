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
        [field: SerializeField] public ParticleSystem HitEffect { get; private set; }
        [field: SerializeField] public BodyParts.Key HitEffectPoint { get; private set; }
        [field: SerializeField] public AbilityPowerValue DamageAmount { get; private set; }

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
            Init();
        }

        private void Init()
        {
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
            var statValue = _source.SharedStats.GetStat(_config.DamageAmount.Stat);
            var damage = (int)(_config.DamageAmount.BonusValue + _config.DamageAmount.StatMultiplier * statValue.Value);

            EventBus.EventBus.RaiseEvent(new DealDamageEvent(_source, _target, damage));
            var effectPoint = _target.BodyParts.GetPoint(_config.HitEffectPoint);
            EventBus.EventBus.RaiseEvent(new VisualParticleEvent(effectPoint, _config.HitEffect));

            _source.AnimatorDispatcher.AnimationEvent -= Shoot;
            _source.ConsumeAction();
            //ServiceLocator.Instance.BattleController.Run();
        }
    }
}