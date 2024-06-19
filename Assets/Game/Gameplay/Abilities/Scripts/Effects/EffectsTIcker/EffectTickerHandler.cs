using System.Linq;
using Game.Gameplay.Abilities.Scripts.Effects.Visual;
using Game.Gameplay.Battle;
using Game.Gameplay.Characters.Scripts.BodyParts;
using Game.Gameplay.Characters.Scripts.Components;
using Game.Gameplay.Characters.Scripts.Components.Effects;
using Game.Gameplay.EventBus.Events;
using Game.Gameplay.EventBus.Events.Effects;
using Sirenix.Utilities;
using UnityEngine;

namespace Game.Gameplay.EventBus.Handlers.Turn
{
    public class EffectTickerHandler : BaseHandler<NextTimeEvent>
    {
        private readonly BattleContainer _battleContainer;

        public EffectTickerHandler(EventBus eventBus, BattleContainer battleContainer) : base(eventBus)
        {
            _battleContainer = battleContainer;
        }

        protected override void HandleEvent(NextTimeEvent evt)
        {
            var componentEffectsEnumerable = _battleContainer.GetAllCharacters().Select(t => t.Get<Component_Effects>());
            foreach (var componentEffects in componentEffectsEnumerable)
            {
                if (!componentEffects.TryGetEffect(out IComponent_Effect[] effectDots)) continue;

                foreach (var effect in effectDots)
                {
                    effect.Tick();
                    if (effect.Duration <= 0)
                        componentEffects.RemoveEffect(effect);
                }
            }
        }
    }
}