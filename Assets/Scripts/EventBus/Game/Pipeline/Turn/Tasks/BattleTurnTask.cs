namespace EventBus.Game.Pipeline.Turn.Tasks
{
    public sealed class BattleTurnTask: Task
    {
            private readonly EventBus _eventBus;
        
            public BattleTurnTask( EventBus eventBus)
            {
                _eventBus = eventBus;
            }

            protected override void OnRun()
            {
                //player action
                //ai action
                //_input.OnMove += OnMovePerformed;
            }

            protected override void OnFinish()
            {
            }

            private void OnMovePerformed()
            {
                //_eventBus.RaiseEvent(new ApplyDirectionEvent(_player, direction));
                // use skill
                Finish();
            }
    }
}