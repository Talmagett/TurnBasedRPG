using System;
using JetBrains.Annotations;
using UnityEngine;
using Zenject;

namespace Game.Map.Scripts
{
    [UsedImplicitly]
    public class PlayerMapInput : ITickable
    {
        public Vector3 MoveDir { get; private set; }
        public event Action OnInteract;

        public void Tick()
        {
            Move();
            Interact();
        }

        private void Interact()
        {
            if (Input.GetKeyDown(KeyCode.E))
                OnInteract?.Invoke();
        }

        private void Move()
        {
            var hor = Input.GetAxis("Horizontal");
            var ver = Input.GetAxis("Vertical");
            MoveDir = new Vector3(hor, 0, ver);
        }
    }
}