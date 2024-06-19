using Game.Gameplay.Abilities.Scripts;
using Game.Gameplay.Characters.Scripts;
using Game.Gameplay.Characters.Scripts.Components;
using Game.Gameplay.Characters.Scripts.Keys;
using Game.Gameplay.EventBus.Events;
using UnityEngine;

namespace Game.Gameplay.EventBus.Handlers.Turn
{
    public class CastAbilityHandler : BaseHandler<CastAbilityEvent>
    {
        public CastAbilityHandler(EventBus eventBus) : base(eventBus)
        {
        }
        
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
                var clone = effect.Clone();
                clone.Source = evt.Source;
                clone.Target = evt.AbilityConfig.TargetType == AbilityTargetType.Self?evt.Source:evt.Target;
                EventBus.RaiseEvent(clone);
            }

            EventBus.RaiseEvent(new DelayedEvent(new FinishTurnEvent(evt.Source), evt.AbilityConfig.TurnProcessTime));
        }

    }
}