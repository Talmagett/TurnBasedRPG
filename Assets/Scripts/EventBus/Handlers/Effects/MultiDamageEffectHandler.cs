using System;
using Battle;
using EventBus.Events;
using EventBus.Events.Effects;
using Zenject;

namespace EventBus.Handlers.Effects
{
    public class MultiDamageEffectHandler : IInitializable, IDisposable
    {
        private readonly BattleContainer _battleContainer;

        [Inject]
        public MultiDamageEffectHandler(BattleContainer battleContainer)
        {
            _battleContainer = battleContainer;
        }

        public void Dispose()
        {
            EventBus.Unsubscribe<MultiDamageEffectEvent>(OnCast);
        }

        public void Initialize()
        {
            EventBus.Subscribe<MultiDamageEffectEvent>(OnCast);
        }

        private void OnCast(MultiDamageEffectEvent data)
        {
            var effect = data.DealDamageEffectEvent;
            effect.Source = data.Source;
            for (var i = 0; i < data.Count; i++)
            {
                var randomEnemy = _battleContainer.GetRandomEnemy(data.Source);
                effect.Target = randomEnemy;
                EventBus.RaiseEvent(new DelayedEvent(effect, 0.3f * i));
            }
        }
    }
}