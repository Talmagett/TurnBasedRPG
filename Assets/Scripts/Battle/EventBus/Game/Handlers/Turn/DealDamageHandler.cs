using Battle.EventBus.Game.Events;
using Configs;
using JetBrains.Annotations;
using UnityEngine;

namespace Battle.EventBus.Game.Handlers.Turn
{
    [UsedImplicitly]
    public sealed class DealDamageHandler : BaseHandler<DealDamageEvent>
    {
        public DealDamageHandler(EventBus eventBus) : base(eventBus)
        {
        }

        protected override void HandleEvent(DealDamageEvent evt)
        {
            if (!evt.Target.TryGet("Stats", out SharedCharacterStatistics stats)) return;
            stats.Stats[StatKeys.Health] -= evt.Damage;

            if (stats.Stats[StatKeys.Health] <= 0) Debug.Log(evt.Target + "is Dead");
            //EventBus.RaiseEvent(new DestroyEvent(evt.Entity));
        }
    }
}