using UnityEngine;

namespace Components
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