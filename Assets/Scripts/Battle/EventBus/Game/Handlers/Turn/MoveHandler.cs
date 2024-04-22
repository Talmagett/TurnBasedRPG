using Battle.EventBus.Entities.Common.Components;
using Battle.EventBus.Game.Events;
using JetBrains.Annotations;

namespace Battle.EventBus.Game.Handlers.Turn
{
    [UsedImplicitly]
    public sealed class MoveHandler : BaseHandler<MoveEvent>
    {
        public MoveHandler(EventBus eventBus) : base(eventBus)
        {
        }

        protected override void HandleEvent(MoveEvent evt)
        {
            var coordinatesComponent = evt.Entity.Get<CoordinatesComponent>();
/*
            _levelMap.Entities.RemoveEntity(coordinatesComponent.Value);
            _levelMap.Entities.SetEntity(evt.Coordinates, evt.Entity);
            coordinatesComponent.Value = evt.Coordinates;

            if (!_levelMap.Tiles.IsWalkable(evt.Coordinates)) EventBus.RaiseEvent(new DestroyEvent(evt.Entity));*/
        }
    }
}