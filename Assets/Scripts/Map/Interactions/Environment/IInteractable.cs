using System;
using Entities;

namespace Map.Interactions.Environment
{
    public interface IInteractable
    {
        event Action OnEnter;
        event Action OnExit;

        void Interact(IEntity entity);
    }
}