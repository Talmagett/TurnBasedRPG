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

            var amount = -(int)(evt.HealingAmount.BaseValue + evt.HealingAmount.MultValue * statValue.Value);

            EventBus.RaiseEvent(new DealDamageEvent(evt.Source, evt.Target, amount));
            var effectPoint = evt.Target.Get<BodyParts>().GetPoint(evt.HitEffectPoint);
            EventBus.RaiseEvent(new VisualParticleEvent(effectPoint, evt.HitEffect));
        }
    }
}