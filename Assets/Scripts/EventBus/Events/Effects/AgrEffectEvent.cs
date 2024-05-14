using System;
using Modules.Entities.Scripts;

namespace EventBus.Events.Effects
{
    [Serializable]
    public struct AgrEffectEvent : IEffect
    {
        public IEntity Source { get; set; }
        public IEntity Target { get; set; }
    }
}