using Data;
using JetBrains.Annotations;
using Lessons.Entities.Common.Components;
using Lessons.Game.Events;
using UnityEngine;

namespace Lessons.Game.Handlers.Turn
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
            Debug.Log(evt.Source+":"+evt.Target+":"+evt.Damage);
            stats.health.Value -= evt.Damage;

            if (stats.health.Value <= 0)
            {
                Debug.Log(evt.Target+"is Dead");
                //EventBus.RaiseEvent(new DestroyEvent(evt.Entity));
            }
        }
    }
}