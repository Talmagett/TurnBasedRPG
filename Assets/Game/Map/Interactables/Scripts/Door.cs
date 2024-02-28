using System;
using Components;
using Entities;
using Game.Map.Interactables.Scripts;
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
            if (!entity.TryGet(out Transform teleportingTransform)) return;
            
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