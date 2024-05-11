using Battle.Actors;
using Cysharp.Threading.Tasks;
using Entities;
using EventBus.Events;
using JetBrains.Annotations;
using PrimeTween;

namespace EventBus.Handlers.Turn
{
    [UsedImplicitly]
    public class FinishTurnEventHandler : BaseHandler<FinishTurnEvent>
    {
        protected override void HandleEvent(FinishTurnEvent evt)
        {
            Process(evt.Source).Forget();
        }
        
        private async UniTask Process(IEntity characterEntity)
        {
            await UniTask.Delay(1000);
            EventBus.RaiseEvent(new TurnSelectionEvent(characterEntity,false));
            await UniTask.Delay(1000);
            EventBus.RaiseEvent(new NextTurnEvent());
        }
    }
}