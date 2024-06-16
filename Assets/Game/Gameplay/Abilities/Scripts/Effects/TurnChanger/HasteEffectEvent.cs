using System;
using Game.GameEngine.Entities.Scripts;
using UnityEngine;

namespace Game.Gameplay.EventBus.Events.Effects
{
    [Serializable]
    public struct HasteEffectEvent : IEffect
    {
        [field: SerializeField] public int Duration { get; private set; }
        public IEntity Source { get; set; }
        public IEntity Target { get; set; }
        public IEffect Clone()
        {
            return new HasteEffectEvent
            {
                Source = Source,
                Target = Target,
                Duration = Duration,
            };
        }
    }
}