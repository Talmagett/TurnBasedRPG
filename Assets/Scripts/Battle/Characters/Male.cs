using Battle.EventBus.Game.Events;
using Configs;
using Configs.Abilities;
using Configs.Enums;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Battle.Characters
{
    public class Male : BattleActor
    {
        [SerializeField] private DealDamageAbilityConfig swordAttack;
        [SerializeField] private AbilityConfig heal;
        
        public override async UniTask Run()
        {
            MeleeAttackAsync();
            await UniTask.Delay(1000);

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
            var target = BattleController.GetRandomEnemy(ActorData.Owner);
            swordAttack.Process(EventBus, ActorData, target);
            ActorData.AnimatorDispatcher.AnimationEvent -= Melee;
            BattleController.Run();
        }
    }
}