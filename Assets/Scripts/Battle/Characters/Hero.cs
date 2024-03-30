using System.Threading.Tasks;
using Actors;
using Cysharp.Threading.Tasks;
using EventBus.Game.Events;
using UnityEngine;

namespace Battle.Characters
{
    public class Hero: BattleActor
    {
        [SerializeField] private DealDamageAbility swordAttack;
        [SerializeField] private HealAbility heal;
        
        /*public override async UniTask Run()
        {
            var rand = Random.Range(0, 2);
            if (rand == 0)
                await MeleeAttack();
            else
                await Heal();
        }

        private async UniTask Heal()
        {
            await UniTask.Delay(300);
            ActorData.Animator.SetTrigger(AnimationKeys.GetAnimation(AnimationKeys.Animation.Heal));
            await UniTask.Delay(200);
            var amount = heal.BonusHealth + (int)(heal.MaxHealthPercent * ActorData.stats.mana.Value);
            EventBus.RaiseEvent(new DealDamageEvent(this, BattleController.GetRandomEnemy(Owner), -amount));
            EventBus.RaiseEvent(new VisualParticleEvent(this, heal.ParticleKey));
            BattleController.Run();
        }

        private async UniTask MeleeAttack()
        {
            await UniTask.Delay(400);
            Animator.SetTrigger(AnimationKeys.GetAnimation(AnimationKeys.Animation.Attack1));
            await UniTask.Delay(200);
            var damage = swordAttack.BonusDamage + (int)(swordAttack.AttackPowerMultiplier * stats.attackPower.Value);
            EventBus.RaiseEvent(new DealDamageEvent(this, BattleController.GetRandomEnemy(Owner), damage));
            EventBus.RaiseEvent(new VisualParticleEvent(BattleController.GetRandomEnemy(Owner), swordAttack.ParticleKey));
            BattleController.Run();
        }*/
    }
}