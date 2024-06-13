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
        [field: SerializeField] public ParticleSystem HitEffect { get; private set; }
        [field: SerializeField] public BodyParts.Key HitEffectPoint { get; private set; }
        [field: SerializeField] public AbilityStat HealingAmount { get; private set; }

        public IEntity Source { get; set; }
        public IEntity Target { get; set; }
        public IEffect Clone()
        {
            throw new NotImplementedException();
        }
    }
}