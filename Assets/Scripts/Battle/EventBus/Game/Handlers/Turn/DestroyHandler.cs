using Battle.EventBus.Entities.Common.Components;
using Battle.EventBus.Game.Events;
using JetBrains.Annotations;

namespace Battle.EventBus.Game.Handlers.Turn
{
    [UsedImplicitly]
    public sealed class DestroyHandler : BaseHandler<DestroyEvent>
    {

        public DestroyHandler(EventBus eventBus) : base(eventBus)
        {
        }

        protected override void HandleEvent(DestroyEvent evt)
        {
            if (evt.Entity.TryGet(out DeathComponent deathComponent)) deathComponent.Die();

            var coordinates = evt.Entity.Get<CoordinatesComponent>();
            //_levelMap.Entities.RemoveEntity(coordinates.Value);
        }
    }
}