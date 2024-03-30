using UnityEngine;

namespace Battle.EventBus.Game.Pipeline.Turn.Tasks
{
    public sealed class StartTurnTask : Task
    {
        protected override void OnRun()
        {
            Debug.Log("Start Turn!");

            Finish();
        }
    }
}