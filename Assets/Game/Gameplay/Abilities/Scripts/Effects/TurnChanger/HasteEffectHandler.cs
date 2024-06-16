using System;
using Game.Gameplay.Characters.Scripts.BodyParts;
using Game.Gameplay.Characters.Scripts.Components;
using Game.Gameplay.EventBus.Events;
using Game.Gameplay.EventBus.Events.Effects;
using JetBrains.Annotations;
using UnityEngine;
using Zenject;

namespace Game.Gameplay.EventBus.Handlers.Effects
{
    [UsedImplicitly]
    public sealed class HasteEffectHandler : IInitializable, IDisposable
    {
        private readonly EventBus _eventBus;
        
        [Inject]
        public HasteEffectHandler(EventBus eventBus)
        {
            _eventBus = eventBus;
        }

        void IDisposable.Dispose()
        {
            _eventBus.Unsubscribe<HasteEffectEvent>(OnStunned);
        }

        void IInitializable.Initialize()
        {
            _eventBus.Subscribe<HasteEffectEvent>(OnStunned);
        }

        private void OnStunned(HasteEffectEvent evt)
        {
            var statValue = evt.Target.Get<Component_Turn>().energy;
            statValue.Value = Mathf.Max(statValue.Value-evt.Duration,0);
        }
    }
}