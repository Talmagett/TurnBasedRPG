using Configs.Enums;
using Map.Interactions.Environment;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;
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

        [Range(0.0f, 0.3f)]
        [SerializeField] private float RotationSmoothTime = 0.12f;
        [SerializeField] private float speedChangeRate = 10.0f;
        
        [Space(10)]
        [Tooltip("The height the player can jump")]
        [SerializeField] float jumpHeight = 1.2f;
        
        [SerializeField] private LayerMask groundLayers;
        [SerializeField] private float jumpTimeout = 0.50f;
        [SerializeField] private float fallTimeout = 0.15f;
        [SerializeField] private float groundedOffset = -0.14f;
        [SerializeField] private float groundedRadius = 0.28f;
        [SerializeField] private float gravity = -15.0f;
        [ReadOnly] [SerializeField] private bool grounded = true;

        [Space] [Title("Interaction")] [SerializeField]
        private float interactRadius;

        private InputAction.CallbackContext _context;
        
        private float _jumpTimeoutDelta;
        private float _fallTimeoutDelta;
        
        private bool _isMoving;

        private PlayerInputActions _playerInput;
        private Vector3 _targetDirection;
        
        private GameObject _mainCamera;

        // player
        private float _speed;
        private float _animationBlend;
        private float _targetRotation = 0.0f;
        private float _rotationVelocity;
        private float _verticalVelocity;
        private float _terminalVelocity = 53.0f;
        
        // animation IDs
        private int _animIDSpeed = Animator.StringToHash("Speed");
        private int  _animIDGrounded = Animator.StringToHash("Grounded");
        private int _animIDJump = Animator.StringToHash("Jump");
        private int _animIDFreeFall = Animator.StringToHash("FreeFall");
        private int _animIDMotionSpeed = Animator.StringToHash("MotionSpeed");

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

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position + Vector3.up, interactRadius);
        }

        private void OnDrawGizmosSelected()
        {
            var transparentGreen = new Color(0.0f, 1.0f, 0.0f, 0.35f);
            var transparentRed = new Color(1.0f, 0.0f, 0.0f, 0.35f);

            if (grounded) Gizmos.color = transparentGreen;
            else Gizmos.color = transparentRed;

            // when selected, draw a gizmo in the position of, and matching radius of, the grounded collider
            Gizmos.DrawSphere(
                new Vector3(transform.position.x, transform.position.y - groundedOffset, transform.position.z),
                groundedRadius);
        }

        [Inject]
        public void Construct(PlayerInputActions playerInput)
        {
            _playerInput = playerInput;
            _playerInput.Map.Interact.performed += Interact;
            _playerInput.Map.Move.performed += StartMove;
            _playerInput.Map.Move.canceled += StopMove;
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
            playerAnimator.SetBool(_animIDGrounded, grounded);
        }
        
        private void Move()
        {
            // set target speed based on move speed, sprint speed and if sprint is pressed
            float targetSpeed = moveSpeed;

            // a simplistic acceleration and deceleration designed to be easy to remove, replace, or iterate upon

            // note: Vector2's == operator uses approximation so is not floating point error prone, and is cheaper than magnitude
            // if there is no input, set the target speed to 0
            if (_targetDirection == Vector3.zero) targetSpeed = 0.0f;

            // a reference to the players current horizontal velocity
            float currentHorizontalSpeed = new Vector3(characterController.velocity.x, 0.0f, characterController.velocity.z).magnitude;

            float speedOffset = 0.1f;
            float inputMagnitude = _input.analogMovement ? _input.move.magnitude : 1f;

            // accelerate or decelerate to target speed
            if (currentHorizontalSpeed < targetSpeed - speedOffset ||
                currentHorizontalSpeed > targetSpeed + speedOffset)
            {
                // creates curved result rather than a linear one giving a more organic speed change
                // note T in Lerp is clamped, so we don't need to clamp our speed
                _speed = Mathf.Lerp(currentHorizontalSpeed, targetSpeed * inputMagnitude,
                    Time.deltaTime * speedChangeRate);

                // round speed to 3 decimal places
                _speed = Mathf.Round(_speed * 1000f) / 1000f;
            }
            else
            {
                _speed = targetSpeed;
            }

            _animationBlend = Mathf.Lerp(_animationBlend, targetSpeed, Time.deltaTime * speedChangeRate);
            if (_animationBlend < 0.01f) _animationBlend = 0f;

            // normalise input direction
            Vector3 inputDirection = new Vector3(_targetDirection.x, 0.0f, _targetDirection.y).normalized;

            // note: Vector2's != operator uses approximation so is not floating point error prone, and is cheaper than magnitude
            // if there is a move input rotate player when the player is moving
            if (_targetDirection != Vector3.zero)
            {
                _targetRotation = Mathf.Atan2(inputDirection.x, inputDirection.z) * Mathf.Rad2Deg +
                                  _mainCamera.transform.eulerAngles.y;
                float rotation = Mathf.SmoothDampAngle(transform.eulerAngles.y, _targetRotation, ref _rotationVelocity,
                    RotationSmoothTime);

                // rotate to face input direction relative to camera position
                transform.rotation = Quaternion.Euler(0.0f, rotation, 0.0f);
            }


            Vector3 targetDirection = Quaternion.Euler(0.0f, _targetRotation, 0.0f) * Vector3.forward;

            // move the player
            characterController.Move(targetDirection.normalized * (_speed * Time.deltaTime) +
                             new Vector3(0.0f, _verticalVelocity, 0.0f) * Time.deltaTime);

            // update animator if using character
            playerAnimator.SetFloat(_animIDSpeed, _animationBlend);
            playerAnimator.SetFloat(_animIDMotionSpeed, inputMagnitude);
        }
        
        private void JumpAndGravity()
        {
            if (grounded)
            {
                // reset the fall timeout timer
                _fallTimeoutDelta = fallTimeout;

                // update animator if using character
                    playerAnimator.SetBool(_animIDJump, false);
                    playerAnimator.SetBool(_animIDFreeFall, false);

                // stop our velocity dropping infinitely when grounded
                if (_verticalVelocity < 0.0f)
                {
                    _verticalVelocity = -2f;
                }

                // Jump
                if (_input.jump && _jumpTimeoutDelta <= 0.0f)
                {
                    // the square root of H * -2 * G = how much velocity needed to reach desired height
                    _verticalVelocity = Mathf.Sqrt(jumpHeight * -2f * gravity);

                    // update animator if using character
                        playerAnimator.SetBool(_animIDJump, true);
                }

                // jump timeout
                if (_jumpTimeoutDelta >= 0.0f)
                {
                    _jumpTimeoutDelta -= Time.deltaTime;
                }
            }
            else
            {
                // reset the jump timeout timer
                _jumpTimeoutDelta = jumpTimeout;

                // fall timeout
                if (_fallTimeoutDelta >= 0.0f)
                {
                    _fallTimeoutDelta -= Time.deltaTime;
                }
                else
                {
                    // update animator if using character
                    playerAnimator.SetBool(_animIDFreeFall, true);
                }

                // if we are not grounded, do not jump
                _input.jump = false;
            }

            // apply gravity over time if under terminal (multiply by delta time twice to linearly speed up over time)
            if (_verticalVelocity < TerminalVelocity)
            {
                _verticalVelocity += gravity * Time.deltaTime;
            }
        }
    }
}