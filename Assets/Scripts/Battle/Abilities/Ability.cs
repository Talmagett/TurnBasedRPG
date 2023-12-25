using Battle.Core;
using Battle.Player;

namespace Battle.Abilities
{
    public abstract class Ability
    {
        protected BattleUnit BattleUnit;
        protected IAbilityCaster Caster;

        public Ability(BattleUnit battleUnit, IAbilityCaster caster)
        {
            BattleUnit = battleUnit;
            Caster = caster;
        }

        public abstract void StartAbility();
    }
}