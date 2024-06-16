using System;
using Game.Gameplay.Characters.Scripts.Components;
using Game.Gameplay.Characters.Scripts.Components.Effects;
using Game.Gameplay.EventBus.Events.Effects;
using Game.Gameplay.EventBus.Handlers.Turn;
using JetBrains.Annotations;
using Zenject;

namespace Game.Gameplay.EventBus.Handlers.Effects
{
    [UsedImplicitly]
    public sealed class DoTEffectHandler : IInitializable, IDisposable
    {
        private readonly EventBus _eventBus;

        [Inject]
        public DoTEffectHandler(EventBus eventBus)
        {
            _eventBus = eventBus;
        }

        void IDisposable.Dispose()
        {
            _eventBus.Unsubscribe<DoTEffectEvent>(OnDotCast);
        }

        void IInitializable.Initialize()
        {
            _eventBus.Subscribe<DoTEffectEvent>(OnDotCast);
        }

        private void OnDotCast(DoTEffectEvent evt)
        {
            var componentEffects = evt.Source.Get<Component_Effects>();
            componentEffects.AddEffect(new DoTEffect(evt.Source,evt.Target,evt.Duration,evt.Damage,evt.ProcEffect));
        }
    }
}