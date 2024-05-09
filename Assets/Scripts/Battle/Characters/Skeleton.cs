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
            Debug.Log(ActorData.Get<Ownership>(AtomicAPI.Owner).Owner);
            Debug.Log(target.Get<Ownership>(AtomicAPI.Owner).Owner);
            biteAttack.GetAbilityClone(ActorData, target);
        }
    }
}