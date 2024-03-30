using Battle.EventBus.Entities.Common.Components;
using Battle.EventBus.Game.Events;
using Battle.EventBus.Game.Pipeline.Visual;
using Battle.EventBus.Game.Pipeline.Visual.Tasks;
using JetBrains.Annotations;

namespace Battle.EventBus.Game.Handlers.Visual
{
    [UsedImplicitly]
    public sealed class CollideVisualHandler : BaseHandler<CollideEvent>
    {
        private readonly VisualPipeline _visualPipeline;

        public CollideVisualHandler(EventBus eventBus, VisualPipeline visualPipeline) : base(eventBus)
        {
            _visualPipeline = visualPipeline;
        }

        protected override void HandleEvent(CollideEvent evt)
        {
            var sourcePosition = evt.Entity.Get<PositionComponent>();
            var targetPosition = evt.Target.Get<PositionComponent>();

            var offset = (targetPosition.Value - sourcePosition.Value) * 0.5f;

            _visualPipeline.AddTask(new MoveVisualTask(evt.Entity, sourcePosition.Value + offset));
            _visualPipeline.AddTask(new MoveVisualTask(evt.Entity, sourcePosition.Value));
        }
    }
}