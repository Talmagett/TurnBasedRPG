using System;
using Game.Gameplay.Characters.Scripts.BodyParts;
using Game.Gameplay.Characters.Scripts.Components;
using Game.Gameplay.EventBus.Events;
using Game.Gameplay.EventBus.Events.Effects;
using JetBrains.Annotations;
using Zenject;

namespace Game.Gameplay.EventBus.Handlers.Effects
{
    [UsedImplicitly]
    public sealed class DealDamageEffectHandler : IInitializable, IDisposable
    {
        private readonly EventBus _eventBus;

        [Inject]
        public DealDamageEffectHandler(EventBus eventBus)
        {
            _eventBus = eventBus;
        }

        void IDisposable.Dispose()
        {
            _eventBus.Unsubscribe<DealDamageEffectEvent>(OnDealDamage);
        }

        void IInitializable.Initialize()
        {
            _eventBus.Subscribe<DealDamageEffectEvent>(OnDealDamage);
        }

        private void OnDealDamage(DealDamageEffectEvent evt)
        {
            var componentAttack = evt.Source.Get<Component_Attack>().attackPower;
            var damage = evt.BaseDamageAmount + evt.AttackPowerMultiplication * componentAttack.Value;
            var effectsContainer = evt.Target.Get<Component_Effects>();

            var health = evt.Target.Get<Component_Life>().health;
            var defense = evt.Target.Get<Component_Defense>().defense;
            var currentHealth = health.Value;
            damage *=100 / (100 + defense.Value * (1 - evt.PenetrationPercent));
            
            if (effectsContainer.TryGetEffect(out ShieldEffectEvent[] shieldEffectEvents))
            {
                foreach (var shield in shieldEffectEvents)
                {
                    shield.ReduceShield((int)damage);
                    if (shield.Amount > 0)
                        return;
                    damage += shield.Amount;
                    effectsContainer.RemoveEffect(shield);
                }
            }
            
            currentHealth -= (int)damage;
            health.Value = currentHealth;
            if (health.Value <= 0)
                _eventBus.RaiseEvent(new DestroyCharacterEntityEvent(evt.Target));
        }
    }
}