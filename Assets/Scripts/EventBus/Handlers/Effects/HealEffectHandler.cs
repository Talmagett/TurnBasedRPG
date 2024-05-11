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
    public sealed class HealEffectHandler : IInitializable, IDisposable
    {
        void IDisposable.Dispose()
        {
            EventBus.Unsubscribe<HealEffectEvent>(OnDealDamage);
        }

        void IInitializable.Initialize()
        {
            EventBus.Subscribe<HealEffectEvent>(OnDealDamage);
        }

        private void OnDealDamage(HealEffectEvent evt)
        {
            var statValue = evt.Source.Get<Component_Attack>().attackPower;
            var damage = -(int)(evt.HealingAmount.BaseValue + evt.HealingAmount.MultValue * statValue.Value);

            EventBus.RaiseEvent(new DealDamageEvent(evt.Source, evt.Target, damage));
            var effectPoint = evt.Target.Get<BodyParts>().GetPoint(evt.HitEffectPoint);
            EventBus.RaiseEvent(new VisualParticleEvent(effectPoint, evt.HitEffect));
        }
    }
}