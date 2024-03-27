using Actors;
using Cysharp.Threading.Tasks;
using EventBus.Game;
using EventBus.Game.Events;
using UnityEngine;

namespace Battle.Characters
{
    public class Wolf : Actor
    {
        [SerializeField] private DealDamageAbility biteAttack; 
        public override async UniTask Run()
        {
            await MeleeAttack();
        }
        
        private async UniTask MeleeAttack()
        {
            await UniTask.Delay(400);
            Animator.SetTrigger(AnimationKeys.GetAnimation(AnimationKeys.Animation.Attack1));
            await UniTask.Delay(200);
            var damage = biteAttack.BonusDamage + (int)(biteAttack.AttackPowerMultiplier * stats.attackPower.Value);
            EventBus.RaiseEvent(new DealDamageEvent(this, BattleController.GetRandomEnemy(Owner), damage));
            EventBus.RaiseEvent(new VisualParticleEvent(BattleController.GetRandomEnemy(Owner), biteAttack.ParticleKey));
            BattleController.Run();
        }
    }
}