using Cysharp.Threading.Tasks;

namespace Battle.Characters
{
    public class BattlePlayerCharacter : BattleBaseCharacter
    {
        public override async UniTask Run()
        {
            await UniTask.Delay(1000);
        }
    }
}