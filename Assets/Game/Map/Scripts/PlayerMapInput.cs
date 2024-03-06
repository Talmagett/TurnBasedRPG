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
        public event Action<int> OnCharacterChosed; 
        public event Action OnInteract;
        public event Action OnAttack;
        
        public void Tick()
        {
            Move();
            Interact();
            ChooseCharacter();
            Attack();
        }

        private void Attack()
        {
            if(Input.GetMouseButtonDown(0))
                OnAttack?.Invoke();
        }

        private void ChooseCharacter()
        {
            if(Input.GetKeyDown(KeyCode.Alpha1))
                OnCharacterChosed?.Invoke(1);
            else if(Input.GetKeyDown(KeyCode.Alpha2))
                OnCharacterChosed?.Invoke(2);
            else if(Input.GetKeyDown(KeyCode.Alpha3))
                OnCharacterChosed?.Invoke(3);
            else if(Input.GetKeyDown(KeyCode.Alpha4))
                OnCharacterChosed?.Invoke(4);
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