using Battle.EventBus.Game.Events;
using Configs;
using Configs.Enums;
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
            if (!evt.Target.TryGet("Stats", out SharedCharacterStats stats)) return;
            var currentHealth = stats.GetStat(StatKey.Health).Value;
            currentHealth -= evt.Damage;
            stats.SetStat(StatKey.Health, currentHealth);

            if (stats.GetStat(StatKey.Health).Value <= 0) 
                EventBus.RaiseEvent(new DestroyEvent(evt.Target));
        }
    }
}