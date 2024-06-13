using Game.Gameplay.Characters.Scripts.Components;
using Game.Gameplay.Game.Heroes;
using Game.UI.Scripts.Views.TabMenu;

namespace Game.UI.Scripts.Presenters
{
    public class CharacterDataPresenter
    {
        public CharacterDataPresenter(HeroPersonalDataView view, Hero hero)
        {
            var data = hero.Get<Component_Data>();
            view.SetName(data.name.Value);
            view.SetDescription(data.description.Value);
            view.SetIcon(data.icon.Value);
        }
    }
}