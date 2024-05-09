using Atomic.Objects;
using Configs.Enums;
using Game.Heroes;
using Visual.UI.TabMenu;

namespace Visual.Presenters
{
    public class CharacterDataPresenter
    {
        public CharacterDataPresenter(HeroPersonalDataView view, Hero hero)
        {
            view.SetName(hero.Name);
            //view.SetDescription();
        }
    }
}