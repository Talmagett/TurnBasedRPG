using System;
using System.Linq;
using Atomic.Elements;
using Battle;
using Battle.Actors.Model;
using Battle.Characters;
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
                evt.CurrentActor.Deselect();
            }

            // if (_battleState != BattleState.Going)
            // {
            //     //FinishBattle();
            //     return;
            // }
            var movingUnits = _battleContainer.GetAllCharacters().Where(t =>
            {
                if (!t.TryGet(AtomicAPI.Attack, out Attack attack)) return false;

                return attack.energy.Value <= 0;
            }).ToList();

            if (!movingUnits.Any())
            {
                EventBus.RaiseEvent(new NextTimeEvent());
                return;
            }
            var currentUnit = movingUnits[0];

            if (movingUnits.Any(t => t.Get<Ownership>(AtomicAPI.Owner).Owner != _battleContainer.LastMoved))
            {
                currentUnit = movingUnits.FirstOrDefault(t => t.Get<Ownership>(AtomicAPI.Owner).Owner!= _battleContainer.LastMoved);
            }

            _battleContainer.LastMoved = currentUnit!.Get<Ownership>(AtomicAPI.Owner).Owner;
            EventBus.RaiseEvent(new CharacterTurnEvent(currentUnit));
            EventBus.RaiseEvent(new StartTurnEvent(currentUnit));
        }
    }
}