using Data;
using EventBus.Game.Events;
using JetBrains.Annotations;
using UnityEngine;

namespace EventBus.Game.Handlers.Turn
{
    [UsedImplicitly]
    public sealed class DealDamageHandler : BaseHandler<DealDamageEvent>
    {
        public DealDamageHandler(EventBus eventBus) : base(eventBus)
        {
            
        }

        protected override void HandleEvent(DealDamageEvent evt)
        {
            if (!evt.Target.TryGet("Stats",out SharedCharacterStatistics stats))
            {
                return;
            }
            stats.health.Value -= evt.Damage;

            if (stats.health.Value <= 0)
            {
                Debug.Log(evt.Target+"is Dead");
                //EventBus.RaiseEvent(new DestroyEvent(evt.Entity));
            }
        }
    }
}