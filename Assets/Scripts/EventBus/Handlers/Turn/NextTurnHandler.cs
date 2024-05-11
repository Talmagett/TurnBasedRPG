using System;
using System.Linq;
using Atomic.Elements;
using Battle;
using Battle.Actors.Model;
using Battle.Characters;
using Character.Components;
using Configs.Enums;
using EventBus.Events;
using JetBrains.Annotations;
using UnityEngine;

namespace EventBus.Handlers.Turn
{
    [UsedImplicitly]
    public sealed class NextTurnHandler : BaseHandler<NextTurnEvent>
    {
        private readonly BattleContainer _battleContainer;

        public NextTurnHandler(BattleContainer battleContainer)
        {
            _battleContainer = battleContainer;
        }

        protected override void HandleEvent(NextTurnEvent evt)
        {
            if (evt.CurrentActor != null)
            {
                EventBus.RaiseEvent(new TurnSelectionEvent(evt.CurrentActor,false));
            }
            
            var movingUnits = _battleContainer
                .GetAllCharacters()
                .Where(t => t.Get<Component_Turn>().energy.Value<=0)
                .ToList();

            if (!movingUnits.Any())
            {
                EventBus.RaiseEvent(new NextTimeEvent());
                return;
            }
            var currentUnit = movingUnits[0];

            if (movingUnits.Any(t => t.Get<Component_Owner>().owner.Value != _battleContainer.LastMoved))
            {
                currentUnit = movingUnits.FirstOrDefault(t => t.Get<Component_Owner>().owner.Value!= _battleContainer.LastMoved);
            }

            _battleContainer.LastMoved = currentUnit!.Get<Component_Owner>().owner.Value;
            EventBus.RaiseEvent(new CharacterTurnEvent(currentUnit));
            EventBus.RaiseEvent(new StartTurnEvent(currentUnit));
        }
    }
}