using Game.Configs.Configs.Character;
using Game.Gameplay.Game.Heroes;
using Game.UI.Scripts.Views.TabMenu;

namespace Game.UI.Scripts.Presenters
{
    public class CharacterDataPresenter
    {
        public CharacterDataPresenter(HeroPersonalDataView view, Hero hero)
        {
            view.SetName(hero.Get<CharacterConfig>().Name);
            //view.SetDescription();
        }
    }
}