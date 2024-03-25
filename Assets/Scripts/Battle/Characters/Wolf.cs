using Actors;
using Atomic.Extensions;
using Cysharp.Threading.Tasks;
using PrimeTween;

namespace Battle.Characters
{
    public class Wolf : BattleActor
    {
        //attack
        public override async UniTask Run()
        {
            //raise event, attack
            var target = BattleController.PlayerSide.GetRandom();
            var basePosition = transform.position;
            var targetPosition = target.transform.position;
            var targetDirection = (targetPosition - basePosition).normalized;
            targetPosition -= targetDirection * target.GetVariable<float>("CollisionRadius").Value;
            await Tween.Position(transform, targetPosition, 0.6f,ease:Ease.OutCirc);
            //target.TakeDamage(stats.Value.physicalPower.Value);
            await UniTask.Delay(500);
            if (this == null)
                return;
            await Tween.Position(transform, basePosition, 0.4f,ease:Ease.OutCirc);
            await UniTask.Delay(500);
        }
    }
}