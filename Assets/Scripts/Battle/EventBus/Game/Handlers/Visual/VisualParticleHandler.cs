using Battle.EventBus.Game.Events;
using Battle.EventBus.Game.Pipeline.Visual;
using Battle.EventBus.Game.Pipeline.Visual.Tasks;
using Configs;
using JetBrains.Annotations;
using UnityEngine;

namespace Battle.EventBus.Game.Handlers.Visual
{
    [UsedImplicitly]
    public sealed class VisualParticleHandler : BaseHandler<VisualParticleEvent>
    {
        private readonly ParticleStorage _particleStorage;
        private readonly VisualPipeline _visualPipeline;

        public VisualParticleHandler(EventBus eventBus, VisualPipeline visualPipeline, ParticleStorage particleStorage)
            : base(eventBus)
        {
            _visualPipeline = visualPipeline;
            _particleStorage = particleStorage;
        }

        protected override void HandleEvent(VisualParticleEvent evt)
        {
            var target = evt.Target.Get<Transform>("Transform");
            _visualPipeline.AddTask(new PlayParticleTask(target.position + Vector3.up,
                _particleStorage.GetParticle(evt.ParticleKey)));
        }
    }
}