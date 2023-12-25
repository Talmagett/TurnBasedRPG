using System;
using System.Linq;
using Battle.Abilities;
using Battle.Core;
using Cysharp.Threading.Tasks;
using Battle;
using Battle.AbilityContainers;
using Random = UnityEngine.Random;

namespace Battle.AI
{
    public class ArcherAI:AI
    {
        protected override void StartTurn(BattleUnit selected)
        {
            if (selected != BattleUnit)
                return;
            
            var arrowAttackAbility = selected.Abilities.FirstOrDefault(t => t is ProjectileShootAbility);
            if (arrowAttackAbility == null)
                throw new Exception($"Arrow Caster {gameObject.name} has no ability");
            arrowAttackAbility.StartAbility();
        }

        public override UniTask<TargetResult> GetTarget()
        {
            UniTask.WaitForSeconds(1);
            var battleController = Battle.ServiceLocator.Instance.GetBattleController();

            var playerUnits = battleController.PlayerUnits;
            var randTargetIndex = Random.Range(0, playerUnits.Length);
            var target = playerUnits[randTargetIndex];
            var targetResult = new TargetResult(target.transform.position,target.transform);
            return new UniTask<TargetResult>(targetResult);
        }
    }
}