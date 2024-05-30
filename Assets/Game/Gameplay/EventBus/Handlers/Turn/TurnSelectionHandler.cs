using Game.Gameplay.EventBus.Events;
using PrimeTween;
using UnityEngine;

namespace Game.Gameplay.EventBus.Handlers.Turn
{
    public class TurnSelectionHandler : BaseHandler<TurnSelectionEvent>
    {
        public TurnSelectionHandler(EventBus eventBus) : base(eventBus)
        {
        }

        protected override void HandleEvent(TurnSelectionEvent evt)
        {
            Tween.Scale(evt.Source.Get<Transform>(), Vector3.one * (evt.IsActive ? 1.2f : 1f), 0.3f);
            //Tween.Position(transform, transform.position - transform.forward * 2, 0.3f);*/
        }
    }
}