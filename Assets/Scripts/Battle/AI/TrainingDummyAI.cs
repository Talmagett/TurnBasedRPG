using Battle.Core;
using Cysharp.Threading.Tasks;

namespace Battle.AI
{
    public class TrainingDummyAI:AI
    {
        protected override void StartTurn(BattleUnit selected)
        {
            Process().Forget();
        }

        private async UniTask Process()
        {
            await UniTask.WaitForSeconds(1);
            BattleUnit.EndTurn();
        }

        public override UniTask<TargetResult> GetTarget()
        {            
            return new UniTask<TargetResult>(null);
        }
    }
}