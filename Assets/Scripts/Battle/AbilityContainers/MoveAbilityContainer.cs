using Battle.Abilities;
using Battle.Core;
using Battle.Player;

namespace Battle.AbilityContainers
{
    public class MoveAbilityContainer:AbilityContainer
    {
        public override Ability CreateAbility(BattleUnit owner, IAbilityCaster casterType)
        {
            return new MoveAbility(owner, casterType);
        }
    }
}