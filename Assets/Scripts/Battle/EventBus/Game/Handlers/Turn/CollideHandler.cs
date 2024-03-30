using Battle.EventBus.Game.Events;
using JetBrains.Annotations;

namespace Battle.EventBus.Game.Handlers.Turn
{
    [UsedImplicitly]
    public sealed class CollideHandler : BaseHandler<CollideEvent>
    {
        public CollideHandler(EventBus eventBus) : base(eventBus)
        {
        }

        protected override void HandleEvent(CollideEvent evt)
        {
            /*EventBus.RaiseEvent(new DealDamageEvent(evt.Entity, 1));
            EventBus.RaiseEvent(new DealDamageEvent(evt.Target, 1));*/
        }
    }
}