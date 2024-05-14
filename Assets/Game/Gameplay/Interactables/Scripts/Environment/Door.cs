using UnityEngine;

namespace Map.Interactions.Environment
{
    public class Door : Interactable
    {
        [SerializeField] private Transform teleportPlace;

        public override void Interact(Transform target)
        {
            var characterController = target.GetComponent<CharacterController>();
            var dist = teleportPlace.position - target.position;
            characterController.Move(dist);
            target.rotation = teleportPlace.rotation;
        }
    }
}