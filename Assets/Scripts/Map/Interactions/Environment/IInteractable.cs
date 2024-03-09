using System;
using Entities;

namespace Map.Interactables
{
    public interface IInteractable
    {
        event Action OnEnter;
        event Action OnExit;

        void Interact(IEntity entity);
    }
}