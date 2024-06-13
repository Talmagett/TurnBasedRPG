using System;
using Game.Gameplay.Characters.Scripts.BodyParts;
using Game.Gameplay.Characters.Scripts.Components;
using Game.Gameplay.EventBus.Events;
using Game.Gameplay.EventBus.Events.Effects;
using JetBrains.Annotations;
using Zenject;

namespace Game.Gameplay.EventBus.Handlers.Effects
{
    [UsedImplicitly]
    public sealed class DealDamageEffectHandler : IInitializable, IDisposable
    {
        private readonly EventBus _eventBus;

        [Inject]
        public DealDamageEffectHandler(EventBus eventBus)
        {
            _eventBus = eventBus;
        }

        void IDisposable.Dispose()
        {
            _eventBus.Unsubscribe<DealDamageEffectEvent>(OnDealDamage);
        }

        void IInitializable.Initialize()
        {
            _eventBus.Subscribe<DealDamageEffectEvent>(OnDealDamage);
        }

        private void OnDealDamage(DealDamageEffectEvent evt)
        {
            var statValue = evt.Source.Get<Component_Attack>().attackPower;
            var damage = (int)(evt.DamageAmount.BaseValue + evt.DamageAmount.MultValue * statValue.Value);

            _eventBus.RaiseEvent(new DealDamageEvent(evt.Source, evt.Target, damage, evt.PenetrationPercent));
            var effectPoint = evt.Target.Get<BodyParts>().GetPoint(evt.HitEffectPoint);
            _eventBus.RaiseEvent(new VisualParticleEvent(effectPoint, evt.HitEffect));
        }
    }
}