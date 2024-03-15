using Cysharp.Threading.Tasks;
using Map.Characters;

namespace Battle.Characters
{
    public interface IBattleTurn
    {
        void Init(BaseCharacter character);
        UniTask Run();
    }
}