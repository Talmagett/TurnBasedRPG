using Battle.EventBus.Game.Events;
using Battle.EventBus.Game.Pipeline.Visual;
using Battle.EventBus.Game.Pipeline.Visual.Tasks;
using JetBrains.Annotations;

namespace Battle.EventBus.Game.Handlers.Visual
{
    [UsedImplicitly]
    public sealed class DestroyVisualHandler : BaseHandler<DestroyEvent>
    {
        private readonly VisualPipeline _visualPipeline;

        public DestroyVisualHandler(EventBus eventBus, VisualPipeline visualPipeline) : base(eventBus)
        {
            _visualPipeline = visualPipeline;
        }

        protected override void HandleEvent(DestroyEvent evt)
        {
            _visualPipeline.AddTask(new DestroyVisualTask(evt.Entity));
        }
    }
}