using System;
using Game.GameEngine.Entities.Scripts;
using Game.Gameplay.Abilities.Scripts;
using Game.Gameplay.Characters.Scripts.BodyParts;
using UnityEngine;

namespace Game.Gameplay.EventBus.Events.Effects
{
    [Serializable]
    public struct AudioEffectEvent : IEffect
    {
        [field: SerializeField] public AudioClip AudioClip { get; private set; }
        public IEntity Source { get; set; }
        public IEntity Target { get; set; }
        public IEffect Clone()
        {
            return new AudioEffectEvent
            {
                Source = Source,
                Target = Target,
                AudioClip = AudioClip
            };
        }
    }
}