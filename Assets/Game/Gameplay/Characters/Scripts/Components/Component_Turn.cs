using Atomic.Elements;

namespace Game.Gameplay.Characters.Scripts.Components
{
    public class Component_Turn
    {
        public AtomicVariable<int> energy;

        public Component_Turn(int baseEnergy)
        {
            energy = new AtomicVariable<int>(baseEnergy);
        }
    }
}