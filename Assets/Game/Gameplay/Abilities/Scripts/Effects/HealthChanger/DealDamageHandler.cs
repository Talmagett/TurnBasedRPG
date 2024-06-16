using Game.Gameplay.Characters.Scripts.Components;
using Game.Gameplay.EventBus.Events;
using JetBrains.Annotations;
using UnityEngine;

namespace Game.Gameplay.EventBus.Handlers.Turn
{
    [UsedImplicitly]
    public sealed class DealDamageHandler : BaseHandler<DealDamageEvent>
    {
        public DealDamageHandler(EventBus eventBus) : base(eventBus)
        {
        }

        protected override void HandleEvent(DealDamageEvent evt)
        {
            var health = evt.Target.Get<Component_Life>().health;
            var currentHealth = health.Value;
            float damage = evt.Damage;
            currentHealth -= (int)damage;
            health.Value = currentHealth;
            if (health.Value <= 0)
                EventBus.RaiseEvent(new DestroyCharacterEntityEvent(evt.Target));
        }
    }
}