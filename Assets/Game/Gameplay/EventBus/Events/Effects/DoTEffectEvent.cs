using System;
using Game.GameEngine.Entities.Scripts;
using UnityEngine;

namespace Game.Gameplay.EventBus.Events.Effects
{
    [Serializable]
    public struct DoTEffectEvent : IEffect
    {
        [field: SerializeField] public int Duration { get; private set; }
        [field: SerializeField] public int Damage { get; private set; }
        [field: SerializeField] public ParticleSystem HitEffect { get; private set; }

        public IEntity Source { get; set; }
        public IEntity Target { get; set; }
        public IEffect Clone()
        {
            throw new NotImplementedException();
        }
    }
}