using Atomic.Elements;
using Battle;
using Configs.Enums;
using EventBus.Events;
using Sirenix.Utilities;

namespace EventBus.Handlers.Turn
{
    public class NextTimeHandler : BaseHandler<NextTimeEvent>
    {
        private readonly BattleContainer _battleContainer;

        public NextTimeHandler(BattleContainer battleContainer)
        {
            _battleContainer = battleContainer;
        }
        
        protected override void HandleEvent(NextTimeEvent evt)
        {
            _battleContainer.GetAllCharacters().ForEach(t =>
            {
                if (!t.TryGet(AtomicPropertyAPI.CooldownKey, out AtomicVariable<int> cooldown)) return;
                cooldown.Value--;
            });
            EventBus.RaiseEvent(new DelayedEvent(new NextTurnEvent(),0.5f));
        }
    }
}