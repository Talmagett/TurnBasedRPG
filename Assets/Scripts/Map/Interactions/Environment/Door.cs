using System;
using Atomic.Objects;
using Entities;
using Map.Characters;
using UnityEngine;

namespace Map.Interactions.Environment
{
    public class Door : MonoBehaviour, IInteractable
    {
        [SerializeField] private Transform teleportPlace;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out IEntity entity)) return;
            if (!entity.TryGet(out PlayerCharacterController player)) return;
            OnEnter?.Invoke();
        }

        private void OnTriggerExit(Collider other)
        {
            if (!other.TryGetComponent(out IEntity entity)) return;
            if (!entity.TryGet(out PlayerCharacterController player)) return;
            OnExit?.Invoke();
        }

        public event Action OnEnter;
        public event Action OnExit;
        public void Interact(IAtomicObject entity)
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