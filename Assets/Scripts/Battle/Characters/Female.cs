using Battle.EventBus.Game.Events;
using Configs;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Battle.Characters
{
    public class Female : BattleActor
    {
        [SerializeField] private DealDamageAbility swordAttack;
        [SerializeField] private HealAbility heal;

        public override async UniTask Run()
        {
            await base.Run();
                HealAsync();
            return;
            /*
            var rand = Random.Range(0, 2);
            if (rand == 0)
                MeleeAttackAsync();
            else*/
        }
        
        private void HealAsync()
        {
            ActorData.AnimatorDispatcher.AnimationEvent += Heal;
            ActorData.Animator.SetTrigger(AnimationKey.GetAnimation(AnimationKey.Animation.Heal));
        }

        private void Heal()
        {
            var amount = heal.BonusHealth + (int)(heal.MaxHealthPercent * ActorData.SharedStats.GetStat(StatKey.Mana));
            var target = BattleController.GetRandomAlly(ActorData.Owner);
            EventBus.RaiseEvent(new DealDamageEvent(ActorData,target , -amount));
            EventBus.RaiseEvent(new VisualParticleEvent(target, heal.Particle));
            BattleController.Run();
        }
    }
}