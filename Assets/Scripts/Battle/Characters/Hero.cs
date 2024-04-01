using Cysharp.Threading.Tasks;

namespace Battle.Characters
{
    public class Hero : BattleActor
    {
        public override async UniTask Run()
        {
            await UniTask.Delay(1000);
        }
    }
}