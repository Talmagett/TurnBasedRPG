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
            if (!evt.Entity.TryGet(AtomicPropertyAPI.StatsKey, out SharedCharacterStats stats))
                throw new NullReferenceException("no energy");
            
            stats.SetStat(StatKey.Energy, evt.Cost);
        }
    }
}