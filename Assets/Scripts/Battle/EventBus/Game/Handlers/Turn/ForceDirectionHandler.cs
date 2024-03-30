using EventBus.Entities.Common.Components;
using EventBus.Game.Events;
using EventBus.Level;
using JetBrains.Annotations;
using UnityEngine;

namespace EventBus.Game.Handlers.Turn
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
            CoordinatesComponent coordinates = evt.Entity.Get<CoordinatesComponent>();
            Vector2Int destination = coordinates.Value + evt.Direction;

            if (_levelMap.Entities.HasEntity(destination))
            {
                EventBus.RaiseEvent(new CollideEvent(evt.Entity, _levelMap.Entities.GetEntity(destination)));
            }
            else
            {
                EventBus.RaiseEvent(new MoveEvent(evt.Entity, destination));
            }
        }
    }
}