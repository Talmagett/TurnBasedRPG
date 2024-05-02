// using Battle.Actors;
// using Battle.EventBus.Game.Events;
// using EventBus.Events;
// using EventBus.Handlers;
// using JetBrains.Annotations;
//
// namespace Battle.EventBus.Game.Handlers.Turn
// {
//     [UsedImplicitly]
//     public sealed class DestroyHandler : BaseHandler<DestroyEvent>
//     {
//         private readonly BattleController _battleController;
//
//         public DestroyHandler(EventBus eventBus, BattleController battleController) : base(eventBus)
//         {
//             _battleController = battleController;
//         }
//
//         protected override void HandleEvent(DestroyEvent evt)
//         {
//             if(evt.Entity is ActorData actorData)
//                 _battleController.DestroyEnemy(actorData);
//         }
//     }
// }