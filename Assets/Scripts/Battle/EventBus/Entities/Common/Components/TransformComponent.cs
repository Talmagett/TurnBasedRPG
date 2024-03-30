using UnityEngine;

namespace Battle.EventBus.Entities.Common.Components
{
    public sealed class TransformComponent
    {
        public TransformComponent(Transform transform)
        {
            Value = transform;
        }

        public Transform Value { get; }
    }
}