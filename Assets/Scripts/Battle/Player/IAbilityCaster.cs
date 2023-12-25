using Cysharp.Threading.Tasks;

namespace Battle.Player
{
    public interface IAbilityCaster
    {
        UniTask<TargetResult> GetTarget();
    }
}