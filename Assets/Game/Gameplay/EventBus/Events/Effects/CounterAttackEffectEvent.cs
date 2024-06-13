using System;
using Game.GameEngine.Entities.Scripts;

namespace Game.Gameplay.EventBus.Events.Effects
{
    [Serializable]
    public struct CounterAttackEffectEvent : IEffect
    {
        public IEntity Source { get; set; }
        public IEntity Target { get; set; }
        public IEffect Clone()
        {
            throw new NotImplementedException();
        }
    }
}