using Atomic.Elements;

namespace Game.Gameplay.Characters.Scripts.Components
{
    public sealed class Component_Mana
    {
        public AtomicVariable<int> mana;
        public AtomicVariable<int> maxMana;

        public Component_Mana(int baseMana)
        {
            mana = new AtomicVariable<int>(baseMana);
            maxMana = new AtomicVariable<int>(baseMana);
        }
    }
}