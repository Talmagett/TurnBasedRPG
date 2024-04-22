using Configs.Abilities;
using Game;
using UnityEngine;

namespace Battle.Characters
{
    public class Skeleton : BattleActor
    {
        [SerializeField] private DealDamageAbilityConfig biteAttack;

        public override void Run()
        {
            var target = ServiceLocator.Instance.BattleController.GetRandomEnemy(ActorData.Owner);
            biteAttack.GetAbilityClone(ActorData, target);
        }
    }
}