using System;
using UnityEngine;

namespace Map.Interactions.Environment
{
    public abstract class Interactable : MonoBehaviour
    {
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

        public event Action OnEnter;
        public event Action OnExit;

        public abstract void Interact(Transform transform);
    }
}