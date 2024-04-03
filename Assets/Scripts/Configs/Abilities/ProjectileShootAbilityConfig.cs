using System;
using Battle.Actors;
using Battle.EventBus.Game.Events;
using Configs.Abilities.Attributes;
using Configs.Enums;
using Game;
using PrimeTween;
using UnityEngine;
using Object = System.Object;

namespace Configs.Abilities
{
    [Serializable]
    [CreateAssetMenu(fileName = "New Ability", menuName = "SO/Ability/ProjectileShootAbility")]
    public class ProjectileShootAbilityConfig : AbilityConfig
    {
        [field: SerializeField] public GameObject Projectile { get; private set; }
        [field: SerializeField] public ParticleSystem HitEffect { get; private set; }
        [field: SerializeField] public BaseValue BonusDamage { get; private set; }
        [field: SerializeField] public StatMultiplier StatMultiplier { get; private set; }

        public override IAbility GetAbilityClone(ActorData source, ActorData target) =>
            new ProjectileShootAbility(source, target, this);
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
            var projectile = GameObject.Instantiate(_config.Projectile, _source.BodyParts.RightHand.position, Quaternion.identity);
            projectile.transform.LookAt(_target.transform.position);
            Tween.Position(projectile.transform, _target.BodyParts.Chest.position, 0.7f, Ease.InSine).OnComplete(() =>
            {
                GameObject.Destroy(projectile);
                OnHit();
            });
        }

        private void OnHit()
        {
            var attackPowerStat = _source.SharedStats.GetStat(_config.StatMultiplier.Stat);
            var damage = (int)(_config.BonusDamage.Value + _config.StatMultiplier.Multiplier * attackPowerStat.Value);
            
            ServiceLocator.Instance.EventBus.RaiseEvent(new DealDamageEvent(_source, _target, damage));
            ServiceLocator.Instance.EventBus.RaiseEvent(new VisualParticleEvent(_target, _config.HitEffect));

            _source.AnimatorDispatcher.AnimationEvent -= Shoot;
            _source.ConsumeAction();
            ServiceLocator.Instance.BattleController.Run();
        }
    }
}