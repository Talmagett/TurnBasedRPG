using EventBus.Entities.Common.Components;
using EventBus.Game.Events;
using EventBus.Game.Pipeline.Visual;
using EventBus.Game.Pipeline.Visual.Tasks;
using JetBrains.Annotations;
using UnityEngine;

namespace EventBus.Game.Handlers.Visual
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
            PositionComponent sourcePosition = evt.Entity.Get<PositionComponent>();
            PositionComponent targetPosition = evt.Target.Get<PositionComponent>();

            Vector3 offset = (targetPosition.Value - sourcePosition.Value) * 0.5f;
            
            _visualPipeline.AddTask(new MoveVisualTask(evt.Entity, sourcePosition.Value + offset));
            _visualPipeline.AddTask(new MoveVisualTask(evt.Entity, sourcePosition.Value));
        }
    }
}