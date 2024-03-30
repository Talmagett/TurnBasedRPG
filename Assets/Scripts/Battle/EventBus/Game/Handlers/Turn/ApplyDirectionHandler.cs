using Battle.EventBus.Entities.Common.Components;
using Battle.EventBus.Game.Events;
using Battle.EventBus.Level;
using JetBrains.Annotations;

namespace Battle.EventBus.Game.Handlers.Turn
{
    [UsedImplicitly]
    public sealed class ApplyDirectionHandler : BaseHandler<ApplyDirectionEvent>
    {
        private readonly LevelMap _levelMap;

        public ApplyDirectionHandler(EventBus eventBus, LevelMap levelMap) : base(eventBus)
        {
            _levelMap = levelMap;
        }

        protected override void HandleEvent(ApplyDirectionEvent evt)
        {
            var coordinates = evt.Entity.Get<CoordinatesComponent>();
            var targetCoordinates = coordinates.Value + evt.Direction;

            if (_levelMap.Entities.HasEntity(targetCoordinates))
            {
                EventBus.RaiseEvent(new AttackEvent(evt.Entity,
                    _levelMap.Entities.GetEntity(targetCoordinates)));
                return;
            }

            if (_levelMap.Tiles.IsWalkable(targetCoordinates))
                EventBus.RaiseEvent(new MoveEvent(evt.Entity, targetCoordinates));
        }
    }
}