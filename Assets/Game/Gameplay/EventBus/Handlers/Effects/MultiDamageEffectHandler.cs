using System;
using Game.Gameplay.Battle;
using Game.Gameplay.EventBus.Events;
using Game.Gameplay.EventBus.Events.Effects;
using Zenject;

namespace Game.Gameplay.EventBus.Handlers.Effects
{
    public class MultiDamageEffectHandler : IInitializable, IDisposable
    {
        private readonly BattleContainer _battleContainer;
        private readonly EventBus _eventBus;

        [Inject]
        public MultiDamageEffectHandler(BattleContainer battleContainer, EventBus eventBus)
        {
            _battleContainer = battleContainer;
            _eventBus = eventBus;
        }

        public void Dispose()
        {
            _eventBus.Unsubscribe<MultiDamageEffectEvent>(OnCast);
        }

        public void Initialize()
        {
            _eventBus.Subscribe<MultiDamageEffectEvent>(OnCast);
        }

        private void OnCast(MultiDamageEffectEvent data)
        {
            var effect = data.DealDamageEffectEvent;
            effect.Source = data.Source;
            for (var i = 0; i < data.Count; i++)
            {
                var randomEnemy = _battleContainer.GetRandomEnemy(data.Source);
                effect.Target = randomEnemy;
                _eventBus.RaiseEvent(new DelayedEvent(effect, data.Delay * i));
            }
        }
    }
}