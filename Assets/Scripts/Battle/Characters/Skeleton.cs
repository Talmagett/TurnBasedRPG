using Battle.Actors.Model;
using Configs.Abilities;
using Configs.Enums;
using UnityEngine;

namespace Battle.Characters
{
    public class Skeleton : BattleActor
    {
        [SerializeField] private DealDamageAbilityConfig biteAttack;
        
        public override void Run()
        {
            var target = BattleContainer.GetRandomEnemy(ActorData);
            biteAttack.GetAbilityClone(ActorData, target);
        }
    }
}