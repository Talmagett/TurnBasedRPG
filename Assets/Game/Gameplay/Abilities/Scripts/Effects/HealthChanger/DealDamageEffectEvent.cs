using System;
using Game.GameEngine.Entities.Scripts;
using Game.Gameplay.Abilities.Scripts;
using Game.Gameplay.Characters.Scripts.BodyParts;
using UnityEngine;

namespace Game.Gameplay.EventBus.Events.Effects
{
    [Serializable]
    public struct DealDamageEffectEvent : IEffect
    {
        [field: SerializeField] public int BaseDamageAmount { get; set; }
        [field: SerializeField] public float AttackPowerMultiplication { get; set; }
        [field: SerializeField] public float PenetrationPercent { get; set; }

        public IEntity Source { get; set; }
        public IEntity Target { get; set; }
        public IEffect Clone()
        {
            return new DealDamageEffectEvent
            {
                Source = Source,
                Target = Target,
                BaseDamageAmount = BaseDamageAmount,
                AttackPowerMultiplication=AttackPowerMultiplication,
                PenetrationPercent = PenetrationPercent
            };
        }
    }
}