using Components;
using Entities;

namespace Map.Characters
{
    public class PlayerCharacterInstaller : MonoEntityBase
    {
        private void Awake()
        {
            Add(new PlayerTag());
            Add(transform);
        }
    }
}
