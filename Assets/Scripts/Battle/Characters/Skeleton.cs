using Battle.EventBus.Game.Events;
using Configs;
using Configs.Abilities;
using Configs.Enums;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Battle.Characters
{
    public class Skeleton : BattleActor
    {
        [SerializeField] private DealDamageAbility biteAttack;
        public override async UniTask Run()
        {
            MeleeAttackAsync();
            await UniTask.Delay(1000);
        }

        private void MeleeAttackAsync()
        {
            ActorData.AnimatorDispatcher.AnimationEvent += Melee;
            ActorData.Animator.SetTrigger(AnimationKey.GetAnimation(AnimationKey.Animation.Attack));
        }

        private void Melee()
        {
            var target = BattleController.GetRandomEnemy(ActorData.Owner);
            biteAttack.Process(EventBus, ActorData, target);
            ActorData.AnimatorDispatcher.AnimationEvent -= Melee;
            BattleController.Run();
        }
    }
}