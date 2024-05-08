using UnityEngine;

namespace EventBus.Events
{
    public readonly struct MoveEvent : IEvent
    {
        public readonly Transform Transform;
        public readonly Vector3 DeltaDirection;

        public MoveEvent(Transform transform, Vector3 deltaDirection)
        {
            Transform = transform;
            DeltaDirection = deltaDirection;
        }
    }
}