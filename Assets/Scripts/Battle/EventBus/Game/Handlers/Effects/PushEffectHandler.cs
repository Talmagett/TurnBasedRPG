// using System;
// using Battle.EventBus.Game.Events;
// using Battle.EventBus.Game.Events.Effects;
// using JetBrains.Annotations;
// using Zenject;
//
// namespace Battle.EventBus.Game.Handlers.Effects
// {
//     [UsedImplicitly]
//     public sealed class PushEffectHandler : IInitializable, IDisposable
//     {
//         private readonly EventBus _eventBus;
//
//         public PushEffectHandler(EventBus eventBus)
//         {
//             _eventBus = eventBus;
//         }
//
//         void IDisposable.Dispose()
//         {
//             _eventBus.Unsubscribe<PushEffectEvent>(OnPush);
//         }
//
//         void IInitializable.Initialize()
//         {
//             _eventBus.Subscribe<PushEffectEvent>(OnPush);
//         }
//
//         private void OnPush(PushEffectEvent evt)
//         {
//             /*
//             var coordinates = evt.Source.Get<CoordinatesComponent>();
//             var targetCoordinates = evt.Target.Get<CoordinatesComponent>();
//
//             var direction = targetCoordinates.Value - coordinates.Value;
//
//             _eventBus.RaiseEvent(new ForceDirectionEvent(evt.Target, direction));*/
//         }
//     }
// }