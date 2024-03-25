using Atomic.Objects;
using UnityEngine;

namespace Map.Interactions.Environment
{
    public class Door : Interactable
    {
        [SerializeField] private Transform teleportPlace;
        public override void Interact(IAtomicObject entity)
        {
            if (!entity.Is("PlayerTag")) return;
            if (!entity.TryGet("Transform",out Transform teleportingTransform)) return;

            //var dist = teleportPlace.position - teleportingTransform.position;
            //characterController.CharacterController.SimpleMove(dist);
            teleportingTransform.position = teleportPlace.position;
            teleportingTransform.rotation = teleportPlace.rotation;
        }
    }
}