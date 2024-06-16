using System;
using Game.GameEngine.Entities.Scripts;

namespace Game.Gameplay.EventBus.Events.Effects
{
    [Serializable]
    public struct StealthEffectEvent : IEffect
    {
        public IEntity Source { get; set; }
        public IEntity Target { get; set; }
        public IEffect Clone()
        {
            return new StealthEffectEvent { Source = Source, Target = Target };
        }
    }
}