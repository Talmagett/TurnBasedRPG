using Configs.Abilities;
using UnityEngine;

namespace Battle.Characters
{
    public class Skeleton : BattleActor
    {
        [SerializeField] private DealDamageAbilityConfig biteAttack;
        
        public override void Run()
        {
            var target = BattleContainer.GetRandomEnemy(ActorData.Owner);
            biteAttack.GetAbilityClone(ActorData, target);
        }
    }
}