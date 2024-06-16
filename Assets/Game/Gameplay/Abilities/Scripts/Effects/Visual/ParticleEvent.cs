using Game.GameEngine.Entities.Scripts;
using Game.Gameplay.Characters.Scripts.BodyParts;
using Game.Gameplay.EventBus.Events;
using Game.Gameplay.EventBus.Events.Effects;
using UnityEngine;

namespace Game.Gameplay.Abilities.Scripts.Effects.Visual
{
    public struct ParticleEvent : IEvent
    {
        public readonly ParticleSystem Particle;
        public readonly BodyParts.Key SpawnPoint;
        public readonly float Duration;
        public readonly IEntity Source;
        public readonly IEntity Target;

        public ParticleEvent(IEntity source, IEntity target,ParticleSystem particle, BodyParts.Key spawnPoint, float duration)
        {
            Source = source;
            Target = target;
            Particle = particle;
            SpawnPoint = spawnPoint;
            Duration = duration;
        }
    }
}