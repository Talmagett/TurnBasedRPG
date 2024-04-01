using Battle.EventBus.Game.Events;
using Configs;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Battle.Characters
{
    public class Male : BattleActor
    {
        [SerializeField] private DealDamageAbility swordAttack;
        [SerializeField] private HealAbility heal;
        
        public override async UniTask Run()
        {
            await base.Run();
                MeleeAttackAsync();
            return;
            /*var rand = Random.Range(0, 2);
            if (rand == 0)
            else
                HealAsync();*/
        }

        private void MeleeAttackAsync()
        {
            ActorData.AnimatorDispatcher.AnimationEvent += Melee;
            ActorData.Animator.SetTrigger(AnimationKey.GetAnimation(AnimationKey.Animation.Attack));
        }

        private void Melee()
        {
            var damage = swordAttack.BonusDamage + (int)(swordAttack.AttackPowerMultiplier * ActorData.SharedStats.GetStat(StatKey.AttackPower));
            var target = BattleController.GetRandomEnemy(ActorData.Owner);
            EventBus.RaiseEvent(new DealDamageEvent(ActorData, target, damage));
            EventBus.RaiseEvent(new VisualParticleEvent(target, swordAttack.Particle));
            ActorData.AnimatorDispatcher.AnimationEvent -= Melee;
            BattleController.Run();
        }
    }
}