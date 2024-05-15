using Game.Gameplay.Characters.Scripts.Components;
using Game.Gameplay.Game.Heroes;
using Game.UI.Scripts.Views.TabMenu;

namespace Game.UI.Scripts.Presenters
{
    public class CharacterStatObserver
    {
        public CharacterStatObserver(CharacterStatsView view, Hero hero)
        {
            //characterStats.GetStat(StatKey.AttackPower).Subscribe(UpdateText);
            //for each stat, make presenter

            view.Attack.SetValue(hero.Get<Component_Attack>().attackPower.Value.ToString());
            view.Defense.SetValue(hero.Get<Component_Defense>().defense.Value.ToString());
            view.MaxHealth.SetValue(hero.Get<Component_Life>().maxHealth.Value.ToString());
            view.MaxMana.SetValue(hero.Get<Component_Mana>().maxMana.Value.ToString());
        }
    }
}