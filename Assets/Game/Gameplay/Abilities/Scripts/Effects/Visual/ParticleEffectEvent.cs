using System;
using Game.GameEngine.Entities.Scripts;
using Game.Gameplay.Abilities.Scripts;
using Game.Gameplay.Characters.Scripts.BodyParts;
using UnityEngine;

namespace Game.Gameplay.EventBus.Events.Effects
{
    [Serializable]
    public struct ParticleEffectEvent : IEffect
    {
        [field: SerializeField] public ParticleSystem Particle { get; private set; }
        [field: SerializeField] public BodyParts.Key SpawnPoint { get; private set; }
        [field: SerializeField] public float Duration { get; private set; }
        public IEntity Source { get; set; }
        public IEntity Target { get; set; }

        public IEffect Clone()
        {
            return new ParticleEffectEvent
            {
                Source = Source,
                Target = Target,
                Particle = Particle,
                SpawnPoint = SpawnPoint,
                Duration = Duration
            };
        }
    }
}