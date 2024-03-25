using System;
using Actors;
using Atomic.Elements;
using Atomic.Objects;
using Entities;
using Map.Characters;
using UnityEngine;

namespace Map.Interactions.Environment
{
    public abstract class Interactable : Entity
    {
        [SerializeField] private AtomicVariable<CollisionTag> collisionTag;
        
        public event Action OnEnter;
        public event Action OnExit;

        public override void Awake()
        {
            base.Awake();
            AddProperty("CollisionTag", collisionTag);
        }
        
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