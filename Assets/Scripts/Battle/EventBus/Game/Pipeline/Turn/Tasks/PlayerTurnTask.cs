using Battle.EventBus.Game.Events;
using Entities;
using JetBrains.Annotations;
using UnityEngine;

namespace Battle.EventBus.Game.Pipeline.Turn.Tasks
{
    [UsedImplicitly]
    public sealed class PlayerTurnTask : Task
    {
        private readonly EventBus _eventBus;
        private readonly IEntity _player;

        public PlayerTurnTask(EventBus eventBus)
        {
            _eventBus = eventBus;
            //_player = playerService.Player;
        }

        protected override void OnRun()
        {
            //_input.OnMove += OnMovePerformed;
        }

        protected override void OnFinish()
        {
            //_input.OnMove -= OnMovePerformed;
        }

        private void OnMovePerformed(Vector2Int direction)
        {
            _eventBus.RaiseEvent(new ApplyDirectionEvent(_player, direction));

            Finish();
        }
    }
}