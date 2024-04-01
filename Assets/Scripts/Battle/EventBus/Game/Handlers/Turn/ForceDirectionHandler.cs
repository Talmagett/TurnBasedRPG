using Battle.EventBus.Entities.Common.Components;
using Battle.EventBus.Game.Events;
using JetBrains.Annotations;

namespace Battle.EventBus.Game.Handlers.Turn
{
    [UsedImplicitly]
    public sealed class ForceDirectionHandler : BaseHandler<ForceDirectionEvent>
    {
        public ForceDirectionHandler(EventBus eventBus) : base(eventBus)
        {
        }

        protected override void HandleEvent(ForceDirectionEvent evt)
        {
            var coordinates = evt.Entity.Get<CoordinatesComponent>();
            var destination = coordinates.Value + evt.Direction;
/*
            if (_levelMap.Entities.HasEntity(destination))
                EventBus.RaiseEvent(new CollideEvent(evt.Entity, _levelMap.Entities.GetEntity(destination)));
            else
                EventBus.RaiseEvent(new MoveEvent(evt.Entity, destination));*/
        }
    }
}