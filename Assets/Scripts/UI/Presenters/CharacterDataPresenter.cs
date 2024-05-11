using Game.Heroes;
using UI.Views.TabMenu;

namespace UI.Presenters
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