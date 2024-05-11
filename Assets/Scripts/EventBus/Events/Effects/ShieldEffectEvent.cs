using System;
using Entities;

namespace EventBus.Events.Effects
{
    [Serializable]
    public struct ShieldEffectEvent:IEffect
    {
        public IEntity Source { get; set; }
        public IEntity Target { get; set; }
    }
}