using System;
using EventBus.Entities.Common.Components;
using EventBus.Game.Events.Effects;
using JetBrains.Annotations;
using Zenject;

namespace EventBus.Game.Handlers.Effects
{
    [UsedImplicitly]
    public sealed class DealDamageEffectHandler : IInitializable, IDisposable
    {
        private readonly EventBus _eventBus;

        public DealDamageEffectHandler(EventBus eventBus)
        {
            _eventBus = eventBus;
        }

        void IInitializable.Initialize()
        {
            _eventBus.Subscribe<DealDamageEffectEvent>(OnDealDamage);
        }

        void IDisposable.Dispose()
        {
            _eventBus.Unsubscribe<DealDamageEffectEvent>(OnDealDamage);
        }

        private void OnDealDamage(DealDamageEffectEvent evt)
        {
            int damage = evt.ExtraDamage;
            if (evt.Source.TryGet(out StatsComponent statsComponent))
            {
                damage += statsComponent.Strength;
            }
            
            //_eventBus.RaiseEvent(new DealDamageEvent(evt.Source,evt.Target, damage));
        }
    }
}