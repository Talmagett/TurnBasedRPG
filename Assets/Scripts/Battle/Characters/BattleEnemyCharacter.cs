using Cysharp.Threading.Tasks;

namespace Battle.Characters
{
    public class BattleEnemyCharacter : BattleBaseCharacter
    {
        public override async UniTask Run()
        {
            await UniTask.Delay(1000);
        }
    }
}