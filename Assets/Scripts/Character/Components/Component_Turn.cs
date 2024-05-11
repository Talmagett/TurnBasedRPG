using Atomic.Elements;

namespace Character.Components
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