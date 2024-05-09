using Atomic.Objects;
using Configs.Enums;
using Visual.UI.TabMenu;

namespace Visual.Presenters
{
    public class CharacterDataPresenter
    {
        public CharacterDataPresenter(HeroPersonalDataView view, IAtomicObject atomicObject)
        {
            view.SetName(atomicObject.Get<string>(AtomicAPI.Name));
            //view.SetDescription();
        }
    }
}