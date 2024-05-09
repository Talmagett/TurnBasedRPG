using System;
using Battle.Actors;
using Configs;
using Configs.Enums;
using EventBus.Events;
using EventBus.Events.Effects;
using JetBrains.Annotations;
using Zenject;

namespace EventBus.Handlers.Effects
{
    [UsedImplicitly]
    public sealed class DealDamageEffectHandler : IInitializable, IDisposable
    {
        void IInitializable.Initialize()
        {
            EventBus.Subscribe<DealDamageEffectEvent>(OnDealDamage);
        }
        
        void IDisposable.Dispose()
        {
            EventBus.Unsubscribe<DealDamageEffectEvent>(OnDealDamage);
        }

        private void OnDealDamage(DealDamageEffectEvent evt)
        {
            var source = evt.Source as ActorData;
            var target = evt.Target as ActorData;
            var statValue = source.Get<SharedCharacterStats>(AtomicAPI.SharedStats).GetStat(evt.DamageAmount.Stat);
            var damage = (int)(evt.DamageAmount.BaseValue + evt.DamageAmount.MultValue * statValue.Value);

            EventBus.RaiseEvent(new DealDamageEvent(source, target, damage));
            var effectPoint = target.BodyParts.GetPoint(evt.HitEffectPoint);
            EventBus.RaiseEvent(new VisualParticleEvent(effectPoint, evt.HitEffect));
        }
    }
}

