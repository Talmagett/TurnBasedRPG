using System;
using Game.GameEngine.Entities.Scripts;
using UnityEngine;

namespace Game.Gameplay.EventBus.Events.Effects
{
    [Serializable]
    public struct ShieldEffectEvent : IEffect
    {
        public IEntity Source { get; set; }
        public IEntity Target { get; set; }
        [field:SerializeField] public int Amount { get; set; }
        [field:SerializeField] public int Duration { get; set; }

        public IEffect Clone()
        {
            return new ShieldEffectEvent { Source = Source, Target = Target, Amount = Amount,Duration = Duration};
        }
    }
}