using Components;
using Entities;
using Game.Scripts.Components;
using UnityEngine;

namespace Game.Map.Scripts
{
    public class PlayerCharacterInstaller : MonoEntityBase
    {
        [SerializeField] private CharacterController characterController;
        
        private void Awake()
        {
            Add(new PlayerTag());
            Add(transform);
            Add(new Component_CharacterController(characterController));
        }
    }
}
