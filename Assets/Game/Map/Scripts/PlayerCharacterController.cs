using Entities;
using Game.Map.Interactables.Scripts;
using UnityEngine;
using UnityEngine.AI;
using Zenject;

namespace Game.Map.Scripts
{
    public class PlayerCharacterController : MonoBehaviour
    {
        [SerializeField] private NavMeshAgent agent;
        [SerializeField] private float speed;
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
            var hits =Physics.OverlapSphere(transform.position, interactRadius);
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
            agent.Move(_playerMapInput.MoveDir * speed * Time.deltaTime);
        }
    }
}