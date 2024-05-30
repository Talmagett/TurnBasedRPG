using Game.Gameplay.EventBus.Events;
using JetBrains.Annotations;
using UnityEngine;

namespace Game.Gameplay.EventBus.Handlers.Visual
{
    [UsedImplicitly]
    public sealed class VisualParticleHandler : BaseHandler<VisualParticleEvent>
    {
        public VisualParticleHandler(EventBus eventBus) : base(eventBus)
        {
        }

        protected override void HandleEvent(VisualParticleEvent evt)
        {
            if (evt.Particle == null)
                return;
            var vfx = Object.Instantiate(evt.Particle, evt.Target.position, evt.Target.rotation);
            Object.Destroy(vfx.gameObject, evt.Duration);
        }
    }
}