using System;
using Components;
using Entities;
using UnityEngine;

namespace Map.Interactables
{
    public class Door : MonoBehaviour, IInteractable
    {
        [SerializeField] private Transform teleportPlace;
        
        public event Action OnEnter;
        public event Action OnExit;
        
        public void Interact(IEntity entity)
        {
            if (!entity.TryGet(out Component_CharacterController characterController)) return;
            if (!entity.TryGet(out Transform teleportingTransform)) return;

            //var dist = teleportPlace.position - teleportingTransform.position;
            //characterController.CharacterController.SimpleMove(dist);
            teleportingTransform.position = teleportPlace.position;
            teleportingTransform.rotation = teleportPlace.rotation;
        }

        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out IEntity entity)) return;
            if (!entity.TryGet(out PlayerTag playerTag)) return;
            OnEnter?.Invoke();
        }

        private void OnTriggerExit(Collider other)
        {
            if (!other.TryGetComponent(out IEntity entity)) return;
            if (!entity.TryGet(out PlayerTag playerTag)) return;
            OnExit?.Invoke();
        }
    }
}