using System;
using Battle.Actors.Model;
using Configs;
using Configs.Enums;
using EventBus.Events;

namespace EventBus.Handlers.Turn
{
    public class ConsumeActionHandler : BaseHandler<ConsumeEnergyEvent>
    {
        protected override void HandleEvent(ConsumeEnergyEvent evt)
        {
            if (!evt.Entity.TryGet(AtomicAPI.Attack, out Attack energy))
                throw new NullReferenceException("no energy");
            
            energy.energy.Value=evt.Cost;
        }
    }
}