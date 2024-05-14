using Game.Gameplay.EventBus.Events;
using JetBrains.Annotations;

namespace Game.Gameplay.EventBus.Handlers.Turn
{
    [UsedImplicitly]
    public class FinishTurnEventHandler : BaseHandler<FinishTurnEvent>
    {
        protected override void HandleEvent(FinishTurnEvent evt)
        {
            EventBus.RaiseEvent(new TurnSelectionEvent(evt.Source, false));
            EventBus.RaiseEvent(new DelayedEvent(new NextTurnEvent(), 1));
        }
    }
}