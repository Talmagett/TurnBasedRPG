using System;
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

        public LayerMask GroundLayers;
        public float FallTimeout = 0.15f;
        public float GroundedOffset = -0.14f;
        public float GroundedRadius = 0.28f;
        public float Gravity = -15.0f;

        private float _fallTimeoutDelta;
        
        private float _verticalVelocity;
        private float _terminalVelocity = 53.0f;
        
        private PlayerInputActions _playerInput;
        private InputAction.CallbackContext _context;
        public bool Grounded = true;
        private Vector3 _targetDirection;
        
        [Inject]
        public void Construct(PlayerInputActions playerInput)
        {
            _playerInput = playerInput;
            _playerInput.Map.Interact.performed += Interact;
            _playerInput.Map.Move.performed += StartMove;
            _playerInput.Map.Move.canceled += StopMove;
        }

        private void Start()
        {
            _fallTimeoutDelta = FallTimeout;
            _verticalVelocity = 0;
        }

        private void OnDestroy()
        {
            _playerInput.Map.Interact.performed -= Interact;
            _playerInput.Map.Move.performed -= StartMove;
            _playerInput.Map.Move.canceled -= StopMove;
        }

        private void Update()
        {
            JumpAndGravity();
            GroundedCheck();
            Move();
            if (IsMoving)
            {
                Move(_context);
            }
            else
            {
                _targetDirection = Vector3.zero;
            }
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
            _targetDirection = new Vector3(moveDirection2D.x, 0, moveDirection2D.y);
            
            var targetRotation = Quaternion.LookRotation(_targetDirection,Vector3.up);
            transform.rotation = Quaternion.Lerp(transform.rotation,targetRotation,Time.deltaTime*rotationSpeed);
        }

        private void Move()
        {
            characterController.Move(_targetDirection.normalized * (moveSpeed * Time.deltaTime) +
                                     new Vector3(0.0f, _verticalVelocity, 0.0f) * Time.deltaTime);
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

        private void GroundedCheck()
        {
            Vector3 spherePosition = new Vector3(transform.position.x, transform.position.y - GroundedOffset,
                transform.position.z);
            Grounded = Physics.CheckSphere(spherePosition, GroundedRadius, GroundLayers,
                QueryTriggerInteraction.Ignore);
        }
        

        private void JumpAndGravity()
        {
            if (Grounded)
            {
                _fallTimeoutDelta = FallTimeout;
                if (_verticalVelocity < 0.0f)
                {
                    _verticalVelocity = -2f;
                }
            }
            else
            {
                if (_fallTimeoutDelta >= 0.0f)
                {
                    _fallTimeoutDelta -= Time.deltaTime;
                }
            }

            if (_verticalVelocity < _terminalVelocity)
            {
                _verticalVelocity += Gravity * Time.deltaTime;
            }
        }
        
        private void OnDrawGizmosSelected()
        {
            Color transparentGreen = new Color(0.0f, 1.0f, 0.0f, 0.35f);
            Color transparentRed = new Color(1.0f, 0.0f, 0.0f, 0.35f);

            if (Grounded) Gizmos.color = transparentGreen;
            else Gizmos.color = transparentRed;

            // when selected, draw a gizmo in the position of, and matching radius of, the grounded collider
            Gizmos.DrawSphere(
                new Vector3(transform.position.x, transform.position.y - GroundedOffset, transform.position.z),
                GroundedRadius);
        }
    }
}