using System.Linq;
using Game.Gameplay.Battle;
using Game.Gameplay.Characters.Scripts.Components;
using Game.Gameplay.EventBus.Events;
using JetBrains.Annotations;

namespace Game.Gameplay.EventBus.Handlers.Turn
{
    [UsedImplicitly]
    public sealed class NextTurnHandler : BaseHandler<NextTurnEvent>
    {
        private readonly BattleContainer _battleContainer;

        public NextTurnHandler(EventBus eventBus, BattleContainer battleContainer) : base(eventBus)
        {
            _battleContainer = battleContainer;
        }

        protected override void HandleEvent(NextTurnEvent evt)
        {
            if (evt.CurrentActor != null) EventBus.RaiseEvent(new TurnSelectionEvent(evt.CurrentActor, false));

            if (_battleContainer.CheckForFinish())
                return;
            
            var movingUnits = _battleContainer
                .GetAllCharacters()
                .Where(t => t.Get<Component_Turn>().energy.Value <= 0)
                .ToList();

            if (!movingUnits.Any())
            {
                EventBus.RaiseEvent(new NextTimeEvent());
                return;
            }

            var currentUnit = movingUnits[0];

            if (movingUnits.Any(t => t.Get<Component_Owner>().owner.Value != _battleContainer.LastMoved))
                currentUnit = movingUnits.FirstOrDefault(t =>
                    t.Get<Component_Owner>().owner.Value != _battleContainer.LastMoved);

            _battleContainer.LastMoved = currentUnit!.Get<Component_Owner>().owner.Value;
            EventBus.RaiseEvent(new CharacterTurnEvent(currentUnit));
            EventBus.RaiseEvent(new StartTurnEvent(currentUnit));
        }
    }
}