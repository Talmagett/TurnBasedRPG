using System;
using System.Linq;
using Atomic.Elements;
using Battle;
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
                if (!t.TryGet(AtomicPropertyAPI.CooldownKey, out AtomicVariable<int> cooldown)) return false;

                return cooldown.Value <= 0;
            }).ToList();

            if (!movingUnits.Any())
            {
                EventBus.RaiseEvent(new NextTimeEvent());
                return;
            }
            var currentUnit = movingUnits[0];

            if (movingUnits.Any(t => t.Owner != _battleContainer.LastMoved))
            {
                currentUnit = movingUnits.FirstOrDefault(t => t.Owner!= _battleContainer.LastMoved);
            }

            _battleContainer.LastMoved = currentUnit!.Owner;
            
            if (currentUnit!.TryGet("BattleActor", out BattleActor battleActor))
            {
                EventBus.RaiseEvent(new CharacterTurnEvent(currentUnit));
                currentUnit.Select();
                battleActor.Run();
            }
            else
                throw new NullReferenceException($"No battleActor in unit {currentUnit.ID}");
        }
    }
}