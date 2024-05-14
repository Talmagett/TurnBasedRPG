using System;
using Character.BodyParts;
using Character.Components;
using EventBus.Events;
using EventBus.Events.Effects;
using JetBrains.Annotations;
using Zenject;

namespace EventBus.Handlers.Effects
{
    [UsedImplicitly]
    public sealed class DealDamageEffectHandler : IInitializable, IDisposable
    {
        void IDisposable.Dispose()
        {
            EventBus.Unsubscribe<DealDamageEffectEvent>(OnDealDamage);
        }

        void IInitializable.Initialize()
        {
            EventBus.Subscribe<DealDamageEffectEvent>(OnDealDamage);
        }

        private void OnDealDamage(DealDamageEffectEvent evt)
        {
            var statValue = evt.Source.Get<Component_Attack>().attackPower;
            var damage = (int)(evt.DamageAmount.BaseValue + evt.DamageAmount.MultValue * statValue.Value);

            EventBus.RaiseEvent(new DealDamageEvent(evt.Source, evt.Target, damage));
            var effectPoint = evt.Target.Get<BodyParts>().GetPoint(evt.HitEffectPoint);
            EventBus.RaiseEvent(new VisualParticleEvent(effectPoint, evt.HitEffect));
        }
    }
}