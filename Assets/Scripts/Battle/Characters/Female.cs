using Battle.EventBus.Game.Events;
using Configs;
using Configs.Abilities;
using Configs.Enums;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Battle.Characters
{
    public class Female : BattleActor
    {
        [SerializeField] private DealDamageAbility swordAttack;
        [SerializeField] private DealDamageAbility heal;

        public override async UniTask Run()
        {
            var rand = Random.Range(0, 2);
            if (rand == 0)
                MeleeAttackAsync();
            else
                HealAsync();
            await UniTask.Delay(1000);
        }
        
        private void HealAsync()
        {
            ActorData.AnimatorDispatcher.AnimationEvent += Heal;
            ActorData.Animator.SetTrigger(AnimationKey.GetAnimation(AnimationKey.Animation.Heal));
        }

        private void Heal()
        {
            var target = BattleController.GetRandomAlly(ActorData.Owner);
            heal.Process(EventBus, ActorData, target);
            ActorData.AnimatorDispatcher.AnimationEvent -= Melee;
            BattleController.Run();
        }
        
        
        private void MeleeAttackAsync()
        {
            ActorData.AnimatorDispatcher.AnimationEvent += Melee;
            ActorData.Animator.SetTrigger(AnimationKey.GetAnimation(AnimationKey.Animation.Attack));
        }

        private void Melee()
        {
            var target = BattleController.GetRandomEnemy(ActorData.Owner);
            swordAttack.Process(EventBus, ActorData, target);
            ActorData.AnimatorDispatcher.AnimationEvent -= Melee;
            BattleController.Run();
        }
    }
}