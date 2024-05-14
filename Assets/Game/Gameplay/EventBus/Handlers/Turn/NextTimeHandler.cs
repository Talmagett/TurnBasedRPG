using Game.Gameplay.Battle;
using Game.Gameplay.Characters.Scripts.Components;
using Game.Gameplay.EventBus.Events;
using Sirenix.Utilities;

namespace Game.Gameplay.EventBus.Handlers.Turn
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
            _battleContainer.GetAllCharacters().ForEach(t => { t.Get<Component_Turn>().energy.Value--; });
            EventBus.RaiseEvent(new DelayedEvent(new NextTurnEvent(), 0.5f));
        }
    }
}