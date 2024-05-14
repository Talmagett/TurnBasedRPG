using Game.Gameplay.Characters.Scripts.Components;
using Game.Gameplay.EventBus.Events;

namespace Game.Gameplay.EventBus.Handlers.Turn
{
    public class ConsumeActionHandler : BaseHandler<ConsumeEnergyEvent>
    {
        protected override void HandleEvent(ConsumeEnergyEvent evt)
        {
            evt.Entity.Get<Component_Turn>().energy.Value = evt.Cost;
        }
    }
}