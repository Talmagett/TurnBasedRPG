using Battle.Actors;
using Cysharp.Threading.Tasks;
using EventBus.Events;
using JetBrains.Annotations;

namespace EventBus.Handlers.Turn
{
    [UsedImplicitly]
    public class FinishTurnEventHandler : BaseHandler<FinishTurnEvent>
    {
        protected override void HandleEvent(FinishTurnEvent evt)
        {
            Process(evt.Source as ActorData).Forget();
        }

        private async UniTask Process(ActorData actorData)
        {
            await UniTask.Delay(1000);
            actorData?.Deselect();
            await UniTask.Delay(1000);
            EventBus.RaiseEvent(new NextTurnEvent());
        }
    }
}