using System;
using Game.GameEngine.Entities.Scripts;
using Game.Gameplay.Characters.Scripts.Components.Effects;
using UnityEngine;

namespace Game.Gameplay.EventBus.Events.Effects
{
    [Serializable]
    public struct ShieldEffectEvent : IEffect, IComponent_Effect
    {
        public IEntity Source { get; set; }
        public IEntity Target { get; set; }
        [field:SerializeField] public int Amount { get; set; }
        [field:SerializeField] public int Duration { get; set; }
        
        public void Tick()
        {
            Duration--;
        }

        public void ReduceShield(int amount)
        {
            Amount -= amount;
        }
        
        public IEffect Clone()
        {
            return new ShieldEffectEvent { Source = Source, Target = Target, Amount = Amount,Duration = Duration};
        }
    }
}