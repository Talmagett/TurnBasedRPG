using Game.Gameplay.Characters.Scripts;
using Game.Gameplay.Characters.Scripts.Components;
using Game.Gameplay.Characters.Scripts.Keys;
using Game.Gameplay.EventBus.Events;
using Game.Gameplay.EventBus.Events.Effects;
using UnityEngine;

namespace Game.Gameplay.EventBus.Handlers.Turn
{
    public class CastAbilityHandler : BaseHandler<CastAbilityEvent>
    {
        protected override void HandleEvent(CastAbilityEvent evt)
        {
            evt.Source.Get<Component_Mana>().mana.Value -= evt.AbilityConfig.ManaCost;
            evt.Source.Get<Component_Turn>().energy.Value = evt.AbilityConfig.TurnEnergyCost;

            evt.Source.Get<Animator>().SetTrigger(AnimationKey.GetAnimation(evt.AbilityConfig.AnimationKey));
            evt.Source.Get<AnimatorDispatcher>().AnimationEvent += () => { Cast(evt); };
        }

        private void Cast(CastAbilityEvent evt)
        {
            evt.Source.Get<AnimatorDispatcher>().ClearListeners();
            foreach (var effect in evt.AbilityConfig.Effects)
            {
                effect.Source = evt.Source;
                effect.Target = evt.Target;
                EventBus.RaiseEvent(effect);
            }

            EventBus.RaiseEvent(new DelayedEvent(new FinishTurnEvent(evt.Source), evt.AbilityConfig.TurnProcessTime));
        }
    }
}