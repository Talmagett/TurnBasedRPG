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
            ActorData _source = evt.Source as ActorData;
            ActorData _target = evt.Target as ActorData;
            var statValue = _source.Get<SharedCharacterStats>(AtomicAPI.SharedStats).GetStat(evt.DamageAmount.Stat);
            var damage = (int)(evt.DamageAmount.BaseValue + evt.DamageAmount.MultValue * statValue.Value);

            EventBus.RaiseEvent(new DealDamageEvent(_source, _target, damage));
            var effectPoint = _target.BodyParts.GetPoint(evt.HitEffectPoint);
            EventBus.RaiseEvent(new VisualParticleEvent(effectPoint, evt.HitEffect));


            EventBus.RaiseEvent(new FinishTurnEvent(_source));
        }
    }
}

