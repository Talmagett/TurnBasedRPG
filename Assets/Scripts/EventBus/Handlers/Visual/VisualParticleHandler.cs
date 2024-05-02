// using Battle.EventBus.Game.Events;
// using Battle.EventBus.Game.Pipeline.Visual;
// using Battle.EventBus.Game.Pipeline.Visual.Tasks;
// using JetBrains.Annotations;
// using UnityEngine;
//
// namespace Battle.EventBus.Game.Handlers.Visual
// {
//     [UsedImplicitly]
//     public sealed class VisualParticleHandler : BaseHandler<VisualParticleEvent>
//     {
//         private readonly VisualPipeline _visualPipeline;
//
//         public VisualParticleHandler(EventBus eventBus, VisualPipeline visualPipeline)
//             : base(eventBus)
//         {
//             _visualPipeline = visualPipeline;
//         }
//
//         protected override void HandleEvent(VisualParticleEvent evt)
//         {
//             _visualPipeline.AddTask(new PlayParticleTask(evt.Target.position, evt.Particle));
//         }
//     }
// }

