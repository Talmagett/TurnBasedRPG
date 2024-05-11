using Battle.Actors;
using Configs.Enums;
using Cysharp.Threading.Tasks;
using EventBus.Events;
using UnityEngine;

namespace EventBus.Handlers.Turn.Abilities
{
    public class CastAbilityHandler : BaseHandler<CastAbilityEvent>
    {
        protected override void HandleEvent(CastAbilityEvent evt)
        {
            EventBus.RaiseEvent(new ConsumeEnergyEvent(evt.Source,evt.AbilityConfig.EnergyCost));
            evt.Source.Get<Animator>().SetTrigger(AnimationKey.GetAnimation(evt.AbilityConfig.AnimationKey));
            evt.Source.Get<AnimatorDispatcher>().AnimationEvent += () => { Cast(evt);};
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
            
            EventBus.RaiseEvent(new FinishTurnEvent(evt.Source));
        }
    }
}