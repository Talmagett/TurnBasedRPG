using System;
using System.Linq;
using Game.GameEngine.Entities.Scripts;
using Game.Gameplay.Abilities.Scripts;
using UnityEngine;

namespace Game.Gameplay.EventBus.Events.Effects
{
    [Serializable]
    public struct MultiEffectEvent : IEffect
    {
        public MultiType TargetType;
        public AbilityTargetType AbilityTargetType;
        public int Count;
        public float Delay;
        [SerializeReference] public IEffect[] Effects;
        public IEntity Source { get; set; }
        public IEntity Target { get; set; }
        public IEffect Clone()
        {
            var effect = new MultiEffectEvent
            {
                Source = Source,
                Target = Target,
                TargetType = TargetType,
                AbilityTargetType = AbilityTargetType,
                Count = Count,
                Delay = Delay,
                Effects = Effects.Select(t=>t.Clone()).ToArray()
            };
            return effect;
        }

        public enum MultiType
        {
            Single,
            Random,
            All
        }
    }
}