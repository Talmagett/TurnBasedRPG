using Atomic.Elements;
using Sirenix.OdinInspector;

namespace Game.Gameplay.Characters.Scripts.Components
{
    [System.Serializable]
    public sealed class Component_Mana
    {
        public AtomicVariable<int> maxMana;
        [ReadOnly]
        public AtomicVariable<int> mana;

        public Component_Mana(int baseMana)
        {
            mana = new AtomicVariable<int>(baseMana);
            maxMana = new AtomicVariable<int>(baseMana);
        }
    }
}