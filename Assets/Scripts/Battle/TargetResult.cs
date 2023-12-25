using UnityEngine;

namespace Battle
{
    public class TargetResult
    {
        public readonly Vector3 Point;
        public readonly Transform Target;

        public TargetResult(Vector3 point,Transform target)
        {
            Point = point;
            Target = target;
        }
    }
}