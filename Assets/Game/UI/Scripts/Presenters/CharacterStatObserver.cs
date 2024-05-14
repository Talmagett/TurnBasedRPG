using Game.Configs.Configs;
using Game.Configs.Configs.Enums;
using Game.Gameplay.Game.Heroes;
using Game.UI.Scripts.Views.TabMenu;

namespace Game.UI.Scripts.Presenters
{
    public class CharacterStatObserver
    {
        public CharacterStatObserver(CharacterStatsView view, Hero hero)
        {
            var characterStatsStats = hero.Get<SharedCharacterStats>();

            //characterStats.GetStat(StatKey.AttackPower).Subscribe(UpdateText);
            //for each stat, make presenter

            view.Attack.SetValue(characterStatsStats.GetStat(StatKey.AttackPower).Value.ToString());
            view.Defense.SetValue(characterStatsStats.GetStat(StatKey.Defense).Value.ToString());
            view.MaxHealth.SetValue(characterStatsStats.GetStat(StatKey.MaxHealth).Value.ToString());
            view.MaxMana.SetValue(characterStatsStats.GetStat(StatKey.MaxMana).Value.ToString());
        }
    }
}