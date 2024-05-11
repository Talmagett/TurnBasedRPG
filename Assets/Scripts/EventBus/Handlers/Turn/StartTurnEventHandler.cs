using System;
using Battle.Actors;
using Battle.Characters;
using Configs.Enums;
using Cysharp.Threading.Tasks;
using Entities;
using EventBus.Events;
using JetBrains.Annotations;
using PrimeTween;

namespace EventBus.Handlers.Turn
{
    [UsedImplicitly]
    public class StartTurnEventHandler : BaseHandler<StartTurnEvent>
    {
        protected override void HandleEvent(StartTurnEvent evt)
        {
            Run(evt.Source.Get<BattleActor>()).Forget();
            EventBus.RaiseEvent(new TurnSelectionEvent(evt.Source,true));
        }

        private async UniTask Run(BattleActor battleActor)
        {
            await UniTask.Delay(750);
            battleActor.Run();
        }
    }
}