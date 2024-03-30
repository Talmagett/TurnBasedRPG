using UnityEngine;

namespace Battle.EventBus.Entities.Common.Components
{
    public sealed class PositionComponent
    {
        private readonly Transform _transform;

        public PositionComponent(Transform transform)
        {
            _transform = transform;
        }

        public Vector3 Value
        {
            get => _transform.position;
            set => _transform.position = value;
        }
    }
}