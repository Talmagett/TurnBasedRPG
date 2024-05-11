using Configs.Enums;
using Game.Heroes;
using UI.Views.TabMenu;

namespace UI.Presenters
{
    public class CharacterStatObserver
    {
        public CharacterStatObserver(CharacterStatsView view, Hero hero)
        {
//characterStats.GetStat(StatKey.AttackPower).Subscribe(UpdateText);
//for each stat, make presenter
            view.Attack.SetValue(hero.Stats.GetStat(StatKey.AttackPower).Value.ToString());
            view.Defense.SetValue(hero.Stats.GetStat(StatKey.Defense).Value.ToString());
            view.MaxHealth.SetValue(hero.Stats.GetStat(StatKey.MaxHealth).Value.ToString());
            view.MaxMana.SetValue(hero.Stats.GetStat(StatKey.MaxMana).Value.ToString());
        }
    }
}