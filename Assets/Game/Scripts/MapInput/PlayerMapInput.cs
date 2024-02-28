using UnityEngine;
using Zenject;

namespace MapInput
{
    public class PlayerMapInput : ITickable
    {
        public Vector3 MoveDir { get; private set; }

        public void Tick()
        {
            var hor = Input.GetAxis("Horizontal");
            var ver = Input.GetAxis("Vertical");
            MoveDir = new Vector3(hor, 0, ver);
        }
    }
}