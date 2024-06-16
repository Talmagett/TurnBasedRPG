using System;
using Game.GameEngine.Entities.Scripts;
using Game.Gameplay.Characters.Scripts.Components.Effects;
using UnityEngine;

namespace Game.Gameplay.EventBus.Events.Effects
{
    [Serializable]
    public struct DoTEffectEvent : IEffect
    {
        [field: SerializeField] public int Duration { get; private set; }
        [field: SerializeField] public int Damage { get; private set; }
        [field: SerializeField] public ParticleSystem ProcEffect { get; private set; }

        public IEntity Source { get; set; }
        public IEntity Target { get; set; }
        public IEffect Clone()
        {
            return new DoTEffectEvent
            {
                Source = Source,
                Target = Target,
                Duration = Duration,
                Damage = Damage,
                ProcEffect = ProcEffect
            };
        }
    }
}