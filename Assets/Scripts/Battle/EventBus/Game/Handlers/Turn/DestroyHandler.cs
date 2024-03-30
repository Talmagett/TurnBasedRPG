using EventBus.Entities.Common.Components;
using EventBus.Game.Events;
using EventBus.Level;
using JetBrains.Annotations;

namespace EventBus.Game.Handlers.Turn
{
    [UsedImplicitly]
    public sealed class DestroyHandler : BaseHandler<DestroyEvent>
    {
        private readonly LevelMap _levelMap;

        public DestroyHandler(EventBus eventBus, LevelMap levelMap) : base(eventBus)
        {
            _levelMap = levelMap;
        }

        protected override void HandleEvent(DestroyEvent evt)
        {
            if (evt.Entity.TryGet(out DeathComponent deathComponent))
            {
                deathComponent.Die();
            }

            CoordinatesComponent coordinates = evt.Entity.Get<CoordinatesComponent>();
            _levelMap.Entities.RemoveEntity(coordinates.Value);
        }
    }
}