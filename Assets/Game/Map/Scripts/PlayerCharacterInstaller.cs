using Components;
using Entities;
using UnityEngine;

namespace Game.Map.Scripts
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
