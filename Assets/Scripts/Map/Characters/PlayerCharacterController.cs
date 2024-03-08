using Entities;
using Map.Interactables;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using Zenject;

namespace Map.Characters
{
    public class PlayerCharacterController : MonoBehaviour
    {
        [SerializeField] private CharacterController characterController;
        [SerializeField] private float moveSpeed;
        [SerializeField] private float rotationSpeed;
        
        [SerializeField] private float interactRadius;
        [SerializeField] private MonoEntity entity;
        
        private PlayerInputActions _playerMapInput;
        private PlayerInput _playerInput;
        [Inject]
        public void Construct(PlayerInput playerInput)
        {
            _playerMapInput.Map.Interact.performed += Interact;
            _playerMapInput.Map.Move.performed += Move;
            _playerInput.currentActionMap.actionTriggered += OnTriggered;
        }

        private void OnTriggered(InputAction.CallbackContext obj)
        {
        }

        private void Move(InputAction.CallbackContext obj)
        {
            //obj.ReadValue<float>().
        }

        private void OnDestroy()
        {
            _playerMapInput.Map.Interact.performed -= Interact;
        }

        private void Interact(InputAction.CallbackContext obj)
        {
            var hits = Physics.OverlapSphere(transform.position, interactRadius);
            foreach (var hit in hits)
            {
                if (hit.TryGetComponent(out IInteractable interactable))
                {
                    interactable.Interact(entity);
                }
            }
        }

        private void Update()
        {
            /*
            if (_playerMapInput.MoveDir != Vector3.zero)
            {
                characterController.Move(_playerMapInput.MoveDir * (moveSpeed * Time.deltaTime));
                var targetRotation = Quaternion.LookRotation(_playerMapInput.MoveDir,Vector3.up);
                transform.rotation = Quaternion.Lerp(transform.rotation,targetRotation,Time.deltaTime*rotationSpeed); 
            }*/
        }
    }
}