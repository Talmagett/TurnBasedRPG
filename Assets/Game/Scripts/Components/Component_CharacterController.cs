using UnityEngine;

namespace Game.Scripts.Components
{
    public struct Component_CharacterController
    {
        public CharacterController CharacterController { get; }

        public Component_CharacterController(CharacterController characterController)
        {
            CharacterController = characterController;
        }
    }
}