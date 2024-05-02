using Configs.Enums;
using Map.Interactions.Environment;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Map
{
    public class PlayerCharacterController : MonoBehaviour
    {
        private const float TerminalVelocity = 53.0f;
        [SerializeField] private Animator playerAnimator;

        [Title("Movement")] [SerializeField] private CharacterController characterController;

        [SerializeField] private float moveSpeed;
        [SerializeField] private float rotationSpeed;

        [SerializeField] private LayerMask groundLayers;
        [SerializeField] private float fallTimeout = 0.15f;
        [SerializeField] private float groundedOffset = -0.14f;
        [SerializeField] private float groundedRadius = 0.28f;
        [SerializeField] private float gravity = -15.0f;
        [ReadOnly] [SerializeField] private bool grounded = true;

        [Space] [Title("Interaction")] [SerializeField]
        private float interactRadius;

        private InputAction.CallbackContext _context;
        private float _fallTimeoutDelta;
        private bool _isMoving;

        private PlayerInputActions _playerInput;
        private Vector3 _targetDirection;

        private float _verticalVelocity;
        
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
            _fallTimeoutDelta = fallTimeout;
            _verticalVelocity = 0;
        }

        private void Update()
        {
            JumpAndGravity();
            GroundedCheck();
            Move();
            if (_isMoving)
                Move(_context);
            else
                _targetDirection = Vector3.zero;
        }

        private void OnDestroy()
        {
            _playerInput.Map.Interact.performed -= Interact;
            _playerInput.Map.Move.performed -= StartMove;
            _playerInput.Map.Move.canceled -= StopMove;
        }

        private void StartMove(InputAction.CallbackContext obj)
        {
            _isMoving = true;
            _context = obj;
        }

        private void StopMove(InputAction.CallbackContext obj)
        {
            _isMoving = false;
        }

        private void Move(InputAction.CallbackContext context)
        {
            var moveDirection2D = context.ReadValue<Vector2>();
            _targetDirection = new Vector3(moveDirection2D.x, 0, moveDirection2D.y);

            var targetRotation = Quaternion.LookRotation(_targetDirection, Vector3.up);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        }

        private void Move()
        {
            characterController.Move(_targetDirection.normalized * (moveSpeed * Time.deltaTime) +
                                     new Vector3(0.0f, _verticalVelocity, 0.0f) * Time.deltaTime);
            playerAnimator.SetBool(AnimationKey.GetAnimation(AnimationKey.Animation.IsMoving), _isMoving);
        }

        private void Interact(InputAction.CallbackContext obj)
        {
            var hits = Physics.OverlapSphere(transform.position + Vector3.up, interactRadius);
            foreach (var hit in hits)
                if (hit.TryGetComponent(out Interactable interactable))
                    interactable.Interact(transform);
        }

        private void GroundedCheck()
        {
            var spherePosition = new Vector3(transform.position.x, transform.position.y - groundedOffset,
                transform.position.z);
            grounded = Physics.CheckSphere(spherePosition, groundedRadius, groundLayers,
                QueryTriggerInteraction.Ignore);
        }
        
        private void JumpAndGravity()
        {
            if (grounded)
            {
                _fallTimeoutDelta = fallTimeout;
                if (_verticalVelocity < 0.0f) _verticalVelocity = -2f;
            }
            else
            {
                if (_fallTimeoutDelta >= 0.0f) _fallTimeoutDelta -= Time.deltaTime;
            }

            if (_verticalVelocity < TerminalVelocity) _verticalVelocity += gravity * Time.deltaTime;
        }
        
        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position + Vector3.up, interactRadius);
        }

        private void OnDrawGizmosSelected()
        {
            var transparentGreen = new Color(0.0f, 1.0f, 0.0f, 0.35f);
            var transparentRed = new Color(1.0f, 0.0f, 0.0f, 0.35f);

            Gizmos.color = grounded ? transparentGreen : transparentRed;

            // when selected, draw a gizmo in the position of, and matching radius of, the grounded collider
            Gizmos.DrawSphere(
                new Vector3(transform.position.x, transform.position.y - groundedOffset, transform.position.z),
                groundedRadius);
        }
    }
}