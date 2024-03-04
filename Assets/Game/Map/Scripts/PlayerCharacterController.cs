using Entities;
using Game.Map.Interactables.Scripts;
using UnityEngine;
using Zenject;

namespace Game.Map.Scripts
{
    public class PlayerCharacterController : MonoBehaviour
    {
        [SerializeField] private CharacterController characterController;
        [SerializeField] private float speed;
        [SerializeField] private float interactRadius;
        [SerializeField] private MonoEntity entity;
        [SerializeField] private PlayerCharacter[] playerCharacter;
        
        private PlayerMapInput _playerMapInput;

        [Inject]
        public void Construct(PlayerMapInput playerMapInput)
        {
            _playerMapInput = playerMapInput;
            _playerMapInput.OnInteract += Interact;
            _playerMapInput.OnCharacterChosed += ChangeCharacter;
        }

        private void OnDestroy()
        {
            _playerMapInput.OnInteract -= Interact;
            _playerMapInput.OnCharacterChosed -= ChangeCharacter;
        }

        private void ChangeCharacter(int index)
        {
            index--;
            if (index > playerCharacter.Length-1 || index < 0)
                return;
            for (int i = 0; i < playerCharacter.Length; i++)
            {
                if (i != index)
                    playerCharacter[i].Deactivate();
                else
                    playerCharacter[i].Activate();
            }
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
            characterController.Move(_playerMapInput.MoveDir * speed * Time.deltaTime);
        }
    }
}