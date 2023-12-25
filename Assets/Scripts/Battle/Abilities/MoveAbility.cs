using Battle.Core;
using Battle.Player;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AI;

namespace Battle.Abilities
{
    public class MoveAbility:Ability
    {
        private readonly NavMeshAgent _agent;
        public MoveAbility(BattleUnit battleUnit, IAbilityCaster caster) : base(battleUnit, caster)
        {
            _agent=battleUnit.GetComponent<NavMeshAgent>();
        }

        public override void StartAbility()
        {
            TryMove().Forget();
        }
        
        private async UniTask TryMove()
        {
            var targetResult = await Caster.GetTarget();
            if (targetResult == null) return;

            if (_agent.SetDestination(targetResult.Point))
            {
                await UniTask.WaitUntil(()=>_agent.remainingDistance < 0.1f);
            }

            BattleUnit.EndTurn();
        }
    }
}