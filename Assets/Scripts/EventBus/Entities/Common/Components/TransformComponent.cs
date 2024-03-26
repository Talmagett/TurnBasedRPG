using UnityEngine;

namespace EventBus.Entities.Common.Components
{
    public sealed class TransformComponent
    {
        public Transform Value { get; }

        public TransformComponent(Transform transform)
        {
            Value = transform;
        }
    }
}