using UnityEngine;

namespace EventBus.Game.Pipeline.Turn.Tasks
{
    public sealed class FinishTurnTask : Task
    {
        protected override void OnRun()
        {
            Debug.Log("Finish Turn!");
            
            Finish();
        }
    }
}