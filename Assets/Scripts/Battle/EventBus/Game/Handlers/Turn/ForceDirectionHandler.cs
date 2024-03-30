using Battle.EventBus.Entities.Common.Components;
using Battle.EventBus.Game.Events;
using Battle.EventBus.Level;
using JetBrains.Annotations;

namespace Battle.EventBus.Game.Handlers.Turn
{
    [UsedImplicitly]
    public sealed class ForceDirectionHandler : BaseHandler<ForceDirectionEvent>
    {
        private readonly LevelMap _levelMap;

        public ForceDirectionHandler(EventBus eventBus, LevelMap levelMap) : base(eventBus)
        {
            _levelMap = levelMap;
        }

        protected override void HandleEvent(ForceDirectionEvent evt)
        {
            var coordinates = evt.Entity.Get<CoordinatesComponent>();
            var destination = coordinates.Value + evt.Direction;

            if (_levelMap.Entities.HasEntity(destination))
                EventBus.RaiseEvent(new CollideEvent(evt.Entity, _levelMap.Entities.GetEntity(destination)));
            else
                EventBus.RaiseEvent(new MoveEvent(evt.Entity, destination));
        }
    }
}