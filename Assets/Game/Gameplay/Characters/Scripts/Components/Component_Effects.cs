using System.Collections.Generic;
using System.Linq;
using Game.Gameplay.Characters.Scripts.Components.Effects;
using Game.Gameplay.EventBus.Handlers.Turn;

namespace Game.Gameplay.Characters.Scripts.Components
{
    public sealed class Component_Effects
    {
        private readonly List<IComponent_Effect> _effects=new List<IComponent_Effect>();

        public Component_Effects()
        {
        }
        
        public Component_Effects(IEnumerable<IComponent_Effect> effects)
        {
            _effects.AddRange(effects);
        }

        public void AddEffect(IComponent_Effect effect)
        {
            _effects.Add(effect);
        }

        public bool TryGetEffect<T>(out T[] effects) where T : IComponent_Effect
        {
            effects = _effects.OfType<T>().ToArray();
            return effects.Length > 0;
        }

        public void RemoveEffect(IComponent_Effect effect)
        {
            _effects.Remove(effect);
        }
    }
}