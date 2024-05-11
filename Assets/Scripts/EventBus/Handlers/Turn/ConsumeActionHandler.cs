using Character.Components;
using EventBus.Events;
using UnityEngine;

namespace EventBus.Handlers.Turn
{
    public class ConsumeActionHandler : BaseHandler<ConsumeEnergyEvent>
    {
        protected override void HandleEvent(ConsumeEnergyEvent evt)
        {
            evt.Entity.Get<Component_Turn>().energy.Value = evt.Cost;
        }
    }
}