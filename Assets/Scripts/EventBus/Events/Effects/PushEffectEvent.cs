using System;
using Atomic.Objects;

namespace EventBus.Events.Effects
{
    [Serializable]
    public struct PushEffectEvent : IEffect
    {
        public IAtomicObject Source { get; set; }
        public IAtomicObject Target { get; set; }
    }
}