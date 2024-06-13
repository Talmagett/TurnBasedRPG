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
            Debug.Log(evt.Target.Get<Component_ID>().id.Value);
            var health = evt.Target.Get<Component_Life>().health;
            var defense = evt.Target.Get<Component_Defense>().defense;
            var currentHealth = health.Value;
            float damage = evt.Damage;
            damage *=( 100 / (100 + defense.Value * (1 - evt.Penetration)));
            currentHealth -= (int)damage;
            health.Value = currentHealth;
            if (health.Value <= 0)
                EventBus.RaiseEvent(new DestroyCharacterEntityEvent(evt.Target));
        }
    }
}