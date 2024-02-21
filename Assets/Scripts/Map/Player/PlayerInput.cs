using UnityEngine;

namespace Map.Player
{
    public class PlayerInput
    {
        public Vector3 MoveDirectionInput { get; private set; }
        
        public void Tick()
        {
            var horDir = Input.GetAxis("Horizontal");
            var verDir = Input.GetAxis("Vertical");
            MoveDirectionInput = new Vector3(horDir,0,verDir);
        }
    }
}