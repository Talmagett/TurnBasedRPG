using System;
using Entities;

namespace Game.Map.Interactables.Scripts
{
    public interface IInteractable
    {
        event Action OnEnter;
        event Action OnExit;

        void Interact(IEntity entity);
    }
}