using EventBus.Events;
using JetBrains.Annotations;
using UnityEngine;

namespace EventBus.Handlers.Visual
{
    [UsedImplicitly]
    public sealed class VisualParticleHandler : BaseHandler<VisualParticleEvent>
    {
        protected override void HandleEvent(VisualParticleEvent evt)
        {
            var vfx = GameObject.Instantiate(evt.Particle,evt.Target.position,evt.Target.rotation);
            GameObject.Destroy(vfx.gameObject,evt.Duration);
        }
    }
}