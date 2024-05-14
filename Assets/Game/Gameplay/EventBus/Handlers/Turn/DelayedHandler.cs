using Cysharp.Threading.Tasks;
using Game.Gameplay.EventBus.Events;

namespace Game.Gameplay.EventBus.Handlers.Turn
{
    public class DelayedHandler : BaseHandler<DelayedEvent>
    {
        protected override void HandleEvent(DelayedEvent evt)
        {
            RaiseEvent(evt.NextEvent, evt.Delay).Forget();
        }

        private async UniTask RaiseEvent(IEvent evt, float delay)
        {
            await UniTask.Delay((int)(delay * 1000));
            EventBus.RaiseEvent(evt);
        }
    }
}