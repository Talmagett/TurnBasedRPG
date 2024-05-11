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
            if (evt.Particle == null)
                return;
            var vfx = Object.Instantiate(evt.Particle, evt.Target.position, evt.Target.rotation);
            Object.Destroy(vfx.gameObject, evt.Duration);
        }
    }
}