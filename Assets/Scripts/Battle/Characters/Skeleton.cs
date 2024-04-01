using Battle.Actors;
using Battle.EventBus.Game.Events;
using Configs;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Battle.Characters
{
    public class Skeleton : BattleActor
    {
        [SerializeField] private DealDamageAbility biteAttack;
        public override async UniTask Run()
        {
            await base.Run();
            MeleeAttack();
        }

        private void MeleeAttack()
        {
            ActorData.AnimatorDispatcher.AnimationEvent += Melee;
            ActorData.Animator.SetTrigger(AnimationKey.GetAnimation(AnimationKey.Animation.Attack));
        }

        private void Melee()
        {
            var damage = biteAttack.BonusDamage + (int)(biteAttack.AttackPowerMultiplier * ActorData.SharedStats.GetStat(StatKey.AttackPower));
            EventBus.RaiseEvent(new DealDamageEvent(ActorData, BattleController.GetRandomEnemy(ActorData.Owner), damage));
            EventBus.RaiseEvent(new VisualParticleEvent(BattleController.GetRandomEnemy(ActorData.Owner), biteAttack.Particle));
            ActorData.AnimatorDispatcher.AnimationEvent -= Melee;
            BattleController.Run();
        }
    }
}