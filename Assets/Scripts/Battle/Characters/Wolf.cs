using Actors;
using Battle.Components;
using Cysharp.Threading.Tasks;
using EventBus.Game.Events;
using UnityEngine;

namespace Battle.Characters
{
    public class Wolf : Actor
    {
        [SerializeField] private MeleeAttack biteAttack; 
        //attack
        public override async UniTask Run()
        {
            await UniTask.Delay(500);
            EventBus.RaiseEvent(new DealDamageEvent(this,BattleController.GetRandomEnemy(Owner), stats.attackPower.Value));
            EventBus.RaiseEvent(new VisualParticleEvent(BattleController.GetRandomEnemy(Owner), biteAttack.hitParticle));
            BattleController.Run();
            //raise event, attack
            /*var target = BattleController.PlayerSide.GetRandom();
            var basePosition = transform.position;
            var targetPosition = target.transform.position;
            var targetDirection = (targetPosition - basePosition).normalized;
            targetPosition -= targetDirection * target.GetVariable<float>("CollisionRadius").Value;
            await Tween.Position(transform, targetPosition, 0.6f,ease:Ease.OutCirc);
            //target.TakeDamage(stats.Value.physicalPower.Value);
            await UniTask.Delay(500);
            if (this == null)
                return;
            await Tween.Position(transform, basePosition, 0.4f,ease:Ease.OutCirc);*/
        }
    }
}