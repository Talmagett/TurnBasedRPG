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
    public sealed class ShieldEffectHandler : IInitializable, IDisposable
    {
        private readonly EventBus _eventBus;

        [Inject]
        public ShieldEffectHandler(EventBus eventBus)
        {
            _eventBus = eventBus;
        }

        void IDisposable.Dispose()
        {
            _eventBus.Unsubscribe<ShieldEffectEvent>(OnCast);
        }

        void IInitializable.Initialize()
        {
            _eventBus.Subscribe<ShieldEffectEvent>(OnCast);
        }

        private void OnCast(ShieldEffectEvent evt)
        {
            evt.Target.Get<Component_Effects>().AddEffect(evt);
        }
    }
}