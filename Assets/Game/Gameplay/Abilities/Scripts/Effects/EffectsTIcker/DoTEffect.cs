using Game.GameEngine.Entities.Scripts;
using Game.Gameplay.Characters.Scripts.Components.Effects;
using Game.Gameplay.EventBus.Events.Effects;
using UnityEngine;

namespace Game.Gameplay.EventBus.Handlers.Turn
{
    public class DoTEffect : IComponent_Effect
    {
        public int Duration { get; set; }
        public void Tick()
        {
            Duration--;
        }

        public readonly int Damage;
        public readonly ParticleSystem ProcEffect;
        public readonly IEntity Source;
        public readonly IEntity Target;

        public DoTEffect(IEntity source, IEntity target, int duration, int damage, ParticleSystem procEffect)
        {
            Source = source;
            Target = target;
            Duration = duration;
            Damage = damage;
            ProcEffect = procEffect;
        }

    }
}