using Atomic.Elements;
using Sirenix.OdinInspector;

namespace Game.Gameplay.Characters.Scripts.Components
{
    [System.Serializable]
    public class Component_Turn
    {
        [ReadOnly]
        public AtomicVariable<int> energy;

        public Component_Turn(int baseEnergy)
        {
            energy = new AtomicVariable<int>(baseEnergy);
        }
    }
}