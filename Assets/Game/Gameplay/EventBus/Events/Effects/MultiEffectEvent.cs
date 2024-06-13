using System;
using Game.GameEngine.Entities.Scripts;
using UnityEngine;

namespace Game.Gameplay.EventBus.Events.Effects
{
    [Serializable]
    public struct MultiEffectEvent : IEffect
    {
        public MultiType TargetType;
        public int Count;
        public float Delay;
        [SerializeReference] public IEffect[] Effects;
        public IEntity Source { get; set; }
        public IEntity Target { get; set; }
        public IEffect Clone()
        {
            throw new NotImplementedException();
        }

        public enum MultiType
        {
            Single,
            Random,
            All
        }
    }
}