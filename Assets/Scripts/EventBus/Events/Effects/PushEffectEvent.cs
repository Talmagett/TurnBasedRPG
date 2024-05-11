using System;
using Atomic.Objects;
using Entities;

namespace EventBus.Events.Effects
{
    [Serializable]
    public struct PushEffectEvent : IEffect
    {
        public IEntity Source { get; set; }
        public IEntity Target { get; set; }
    }
}