using System;
using Game.Gameplay.Characters.Scripts.BodyParts;
using Game.Gameplay.EventBus.Events.Effects;
using PrimeTween;
using UnityEngine;
using Zenject;
using Object = UnityEngine.Object;

namespace Game.Gameplay.EventBus.Handlers.Effects
{
    public class ShootProjectileAbilityHandler : IInitializable, IDisposable
    {
        void IDisposable.Dispose()
        {
            EventBus.Unsubscribe<ShootProjectileEffectEvent>(OnShoot);
        }

        void IInitializable.Initialize()
        {
            EventBus.Subscribe<ShootProjectileEffectEvent>(OnShoot);
        }

        private void OnShoot(ShootProjectileEffectEvent evt)
        {
            var shootPoint = evt.Source.Get<BodyParts>().GetPoint(evt.ProjectileShootPoint);
            var effectPoint = evt.Target.Get<BodyParts>().GetPoint(evt.HitEffectPoint);

            var projectile = Object.Instantiate(evt.Projectile, shootPoint.position, Quaternion.identity);
            projectile.transform.LookAt(evt.Target.Get<Transform>().position);
            Tween.Position(projectile.transform, effectPoint.position, 0.7f, Ease.InSine).OnComplete(() =>
            {
                Object.Destroy(projectile);
                OnHit(evt);
            });
        }

        private void OnHit(ShootProjectileEffectEvent evt)
        {
            foreach (var effect in evt.EffectsOnHit)
            {
                effect.Source = evt.Source;
                effect.Target = evt.Target;
                EventBus.RaiseEvent(effect);
            }
        }
    }
}