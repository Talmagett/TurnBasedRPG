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
    public class DotEffectTickerHandler : BaseHandler<NextTimeEvent>
    {
        private readonly BattleContainer _battleContainer;

        public DotEffectTickerHandler(EventBus eventBus, BattleContainer battleContainer) : base(eventBus)
        {
            _battleContainer = battleContainer;
        }

        protected override void HandleEvent(NextTimeEvent evt)
        {
            var componentEffectsEnumerable = _battleContainer.GetAllCharacters().Select(t => t.Get<Component_Effects>());
            foreach (var componentEffects in componentEffectsEnumerable)
            {
                if (!componentEffects.TryGetEffect(out DoTEffect[] effectDots)) continue;
                
                foreach (var effect in effectDots)
                {
                    EventBus.RaiseEvent(new DealDamageEvent(effect.Source, effect.Target, effect.Damage, 1));
                    EventBus.RaiseEvent(new ParticleEvent(effect.Source,effect.Target,effect.ProcEffect,BodyParts.Key.Chest,2));
                    Debug.Log("tick poison");
                    effect.Duration--;
                    if (effect.Duration <= 0)
                        componentEffects.RemoveEffect(effect);
                }
            }
        }
    }
}