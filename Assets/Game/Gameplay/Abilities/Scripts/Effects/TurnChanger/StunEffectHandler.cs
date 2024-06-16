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
    public sealed class StunEffectHandler : IInitializable, IDisposable
    {
        private readonly EventBus _eventBus;
        
        [Inject]
        public StunEffectHandler(EventBus eventBus)
        {
            _eventBus = eventBus;
        }

        void IDisposable.Dispose()
        {
            _eventBus.Unsubscribe<StunEffectEvent>(OnStunned);
        }

        void IInitializable.Initialize()
        {
            _eventBus.Subscribe<StunEffectEvent>(OnStunned);
        }

        private void OnStunned(StunEffectEvent evt)
        {
            var statValue = evt.Target.Get<Component_Turn>().energy;
            statValue.Value += evt.Duration;
        }
    }
}