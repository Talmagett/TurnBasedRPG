using Atomic.Elements;

namespace Game.Gameplay.Characters.Scripts.Components
{
    public class Component_Defense
    {
        public AtomicVariable<float> defense;
        public AtomicVariable<float> evasion;

        public Component_Defense(int baseDefense, float baseEvasion)
        {
            defense = new AtomicVariable<float>(baseDefense);
            evasion = new AtomicVariable<float>(baseEvasion);
        }
    }
}