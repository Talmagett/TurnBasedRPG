using Configs.Abilities;
using Cysharp.Threading.Tasks;
using Game;
using UnityEngine;

namespace Battle.Characters
{
    public class Skeleton : BattleActor
    {
        [SerializeField] private DealDamageAbilityConfig biteAttack;

        public override async UniTask Run()
        {
            var target = ServiceLocator.Instance.BattleController.GetRandomEnemy(ActorData.Owner);

            var dealDamageAbility = new DealDamageAbility(ActorData, target, biteAttack);
            await UniTask.Delay(1000);
        }
    }
}