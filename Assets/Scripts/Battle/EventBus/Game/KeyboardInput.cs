using System;
using UnityEngine;

namespace Battle.EventBus.Game
{
    public sealed class KeyboardInput : MonoBehaviour
    {
        private void Update()
        {
            var movement = Vector2Int.zero;

            if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) movement.y += 1;

            if (Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)) movement.y -= 1;

            if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D)) movement.x += 1;

            if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A)) movement.x -= 1;

            if (movement != Vector2Int.zero) OnMove?.Invoke(movement);
        }

        public event Action<Vector2Int> OnMove;
    }
}