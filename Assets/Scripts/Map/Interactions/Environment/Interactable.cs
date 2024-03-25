using System;
using Actors;
using Atomic.Elements;
using Atomic.Objects;
using Entities;
using Map.Characters;
using UnityEngine;

namespace Map.Interactions.Environment
{
    public abstract class Interactable : MonoBehaviour
    {
        public event Action OnEnter;
        public event Action OnExit;
        
        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out PlayerCharacterController entity)) return;
            OnEnter?.Invoke();
        }
        
        private void OnTriggerExit(Collider other)
        {
            if (!other.TryGetComponent(out PlayerCharacterController entity)) return;
            OnExit?.Invoke();
        }
        
        public abstract void Interact(IAtomicObject entity);
    }
}