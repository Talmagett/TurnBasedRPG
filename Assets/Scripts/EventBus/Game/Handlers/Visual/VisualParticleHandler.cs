using JetBrains.Annotations;
using Lessons.Entities.Common.Components;
using Lessons.Game.Events;
using Lessons.Game.Pipeline.Visual;
using Lessons.Game.Pipeline.Visual.Tasks;
using UnityEngine;

namespace Lessons.Game.Handlers.Visual
{
    [UsedImplicitly]
    public sealed class VisualParticleHandler : BaseHandler<VisualParticleEvent>
    {
        private readonly VisualPipeline _visualPipeline;
        
        public VisualParticleHandler(EventBus eventBus, VisualPipeline visualPipeline) : base(eventBus)
        {
            _visualPipeline = visualPipeline;
        }

        protected override void HandleEvent(VisualParticleEvent evt)
        {
            var target = evt.Target.Get<Transform>("Transform");
            _visualPipeline.AddTask(new PlayParticleTask(target.position,evt.Particle));
        }
    }
}