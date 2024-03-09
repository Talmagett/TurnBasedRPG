using Entities;
using Map.Interactables;
using UnityEngine;
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

        public bool IsMoving { get; private set; } = false;

        private PlayerInputActions _playerInput;
        private InputAction.CallbackContext _context;
        
        [Inject]
        public void Construct(PlayerInputActions playerInput)
        {
            _playerInput = playerInput;
            _playerInput.Map.Interact.performed += Interact;
            _playerInput.Map.Move.performed += StartMove;
            _playerInput.Map.Move.canceled += StopMove;
        }

        private void OnDestroy()
        {
            _playerInput.Map.Interact.performed -= Interact;
            _playerInput.Map.Move.performed -= StartMove;
            _playerInput.Map.Move.canceled -= StopMove;
        }

        private void StartMove(InputAction.CallbackContext obj)
        {
            IsMoving = true;
            _context = obj;
        }

        private void StopMove(InputAction.CallbackContext obj)
        {
            IsMoving = false;
        }
        
        private void Move(InputAction.CallbackContext context)
        {
            var moveDirection2D = context.ReadValue<Vector2>();
            var moveDirection = new Vector3(moveDirection2D.x, 0, moveDirection2D.y);
            
            characterController.Move(moveDirection * (moveSpeed * Time.deltaTime));
            
            var targetRotation = Quaternion.LookRotation(moveDirection,Vector3.up);
            transform.rotation = Quaternion.Lerp(transform.rotation,targetRotation,Time.deltaTime*rotationSpeed);
        }

        private void Interact(InputAction.CallbackContext obj)
        {
            print("interact");
            return;
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
            if (IsMoving)
            {
                Move(_context);
            }
        }
    }
}