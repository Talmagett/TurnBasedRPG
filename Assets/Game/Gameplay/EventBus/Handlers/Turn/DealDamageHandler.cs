using Character.Components;
using EventBus.Events;
using JetBrains.Annotations;

namespace EventBus.Handlers.Turn
{
    [UsedImplicitly]
    public sealed class DealDamageHandler : BaseHandler<DealDamageEvent>
    {
        protected override void HandleEvent(DealDamageEvent evt)
        {
            var health = evt.Target.Get<Component_Life>().health;
            var currentHealth = health.Value;
            currentHealth -= evt.Damage;
            health.Value = currentHealth;
            if (health.Value <= 0)
                EventBus.RaiseEvent(new DestroyCharacterEntityEvent(evt.Target));
        }
    }
}