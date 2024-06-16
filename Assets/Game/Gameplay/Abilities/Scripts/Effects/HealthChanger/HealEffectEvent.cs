using System;
using Game.GameEngine.Entities.Scripts;
using Game.Gameplay.Abilities.Scripts;
using Game.Gameplay.Characters.Scripts.BodyParts;
using UnityEngine;

namespace Game.Gameplay.EventBus.Events.Effects
{
    [Serializable]
    public struct HealEffectEvent : IEffect
    {
        [field: SerializeField] public int BaseHealingAmount { get; private set; }
        [field: SerializeField] public float MaxHealthMultiplication { get; private set; }

        public IEntity Source { get; set; }
        public IEntity Target { get; set; }
        public IEffect Clone()
        {
            return new HealEffectEvent
            {
                Source = Source,
                Target = Target,
                BaseHealingAmount = BaseHealingAmount,
                MaxHealthMultiplication = MaxHealthMultiplication
            };
        }
    }
}