using System;
using Battle.Actors;
using Battle.Characters;
using Configs.Enums;
using Cysharp.Threading.Tasks;
using EventBus.Events;
using JetBrains.Annotations;

namespace EventBus.Handlers.Turn
{
    [UsedImplicitly]
    public class StartTurnEventHandler : BaseHandler<StartTurnEvent>
    {
        protected override void HandleEvent(StartTurnEvent evt)
        {
            if (!evt.Source.TryGet("BattleActor", out BattleActor battleActor))
                throw new NullReferenceException($"No battleActor in unit {evt.Source.Get(AtomicAPI.Name)}");
            {
                (evt.Source as ActorData)?.Select();

                Run(battleActor).Forget();
            }
        }

        private async UniTask Run(BattleActor battleActor)
        {
            await UniTask.Delay(750);
            battleActor.Run();
        }
    }
}