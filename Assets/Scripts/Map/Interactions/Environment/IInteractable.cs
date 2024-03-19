using System;
using Atomic.Objects;
using Entities;

namespace Map.Interactions.Environment
{
    public interface IInteractable
    {
        event Action OnEnter;
        event Action OnExit;

        void Interact(IAtomicObject entity);
    }
}