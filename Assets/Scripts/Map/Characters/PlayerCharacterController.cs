using Entities;
using Map.Interactables;
using UnityEngine;
using UnityEngine.AI;
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
        
        private PlayerMapInput _playerMapInput;
        
        [Inject]
        public void Construct(PlayerMapInput playerMapInput)
        {
            _playerMapInput = playerMapInput;
            _playerMapInput.OnInteract += Interact;
        }
        
        private void OnDestroy()
        {
            _playerMapInput.OnInteract -= Interact;
        }

        private void Interact()
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
            if (_playerMapInput.MoveDir != Vector3.zero)
            {
                characterController.Move(_playerMapInput.MoveDir * (moveSpeed * Time.deltaTime));
                var targetRotation = Quaternion.LookRotation(_playerMapInput.MoveDir,Vector3.up);
                transform.rotation = Quaternion.Lerp(transform.rotation,targetRotation,Time.deltaTime*rotationSpeed); 
            }
        }
    }
}