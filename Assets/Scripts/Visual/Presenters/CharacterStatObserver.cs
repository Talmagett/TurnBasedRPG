using Atomic.Objects;
using Configs;
using Configs.Enums;
using Visual.UI.TabMenu;

namespace Visual.Presenters
{
    public class CharacterStatObserver
    {
        public CharacterStatObserver(CharacterStatsView view, IAtomicObject actor)
        {
            if (!actor.TryGet(AtomicAPI.SharedStats, out SharedCharacterStats characterStats)) return;
//characterStats.GetStat(StatKey.AttackPower).Subscribe(UpdateText);
//for each stat, make presenter
            view.Attack.SetValue(characterStats.GetStat(StatKey.AttackPower).Value.ToString());
            view.Defense.SetValue(characterStats.GetStat(StatKey.Defense).Value.ToString());
            view.MaxHealth.SetValue(characterStats.GetStat(StatKey.MaxHealth).Value.ToString());
            view.MaxMana.SetValue(characterStats.GetStat(StatKey.MaxMana).Value.ToString());
        }
    }
}