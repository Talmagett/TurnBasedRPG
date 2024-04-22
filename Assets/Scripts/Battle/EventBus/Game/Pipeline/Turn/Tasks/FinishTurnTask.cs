using Game;
using UnityEngine;

namespace Battle.EventBus.Game.Pipeline.Turn.Tasks
{
    public sealed class FinishTurnTask : Task
    {
        protected override void OnRun()
        {
            Debug.Log("Finish Turn!");
            ServiceLocator.Instance.BattleController.BattleQueue.CurrentCharacter.ActorData.Deselect();
            ServiceLocator.Instance.BattleController.NextTurn();
            Finish();
        }
    }
}