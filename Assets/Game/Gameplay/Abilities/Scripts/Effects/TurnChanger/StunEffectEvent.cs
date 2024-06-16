using System;
using Game.GameEngine.Entities.Scripts;
using UnityEngine;

namespace Game.Gameplay.EventBus.Events.Effects
{
    [Serializable]
    public struct StunEffectEvent : IEffect
    {
        [field: SerializeField] public int Duration { get; private set; }
        public IEntity Source { get; set; }
        public IEntity Target { get; set; }
        public IEffect Clone()
        {
            var effect = new StunEffectEvent
            {
                Source = Source,
                Target = Target,
                Duration = Duration,
            };
            return effect;
        }
    }
}