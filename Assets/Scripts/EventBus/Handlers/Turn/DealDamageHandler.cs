using Configs;
using Configs.Enums;
using EventBus.Events;
using JetBrains.Annotations;

namespace EventBus.Handlers.Turn
{
    [UsedImplicitly]
    public sealed class DealDamageHandler : BaseHandler<DealDamageEvent>
    {
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