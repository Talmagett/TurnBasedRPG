using Actors;
using Cysharp.Threading.Tasks;

namespace Battle.Characters
{
    public class Father : BattleActor
    {
        public override async UniTask Run()
        {
            await UniTask.Delay(1000);
        }
    }
}