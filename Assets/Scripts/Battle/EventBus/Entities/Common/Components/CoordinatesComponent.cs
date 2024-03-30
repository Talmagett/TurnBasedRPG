using Battle.EventBus.Utils;
using UnityEngine;

namespace Battle.EventBus.Entities.Common.Components
{
    public sealed class CoordinatesComponent
    {
        private readonly AtomicVariable<Vector2Int> _coordinates;

        public CoordinatesComponent(AtomicVariable<Vector2Int> coordinates)
        {
            _coordinates = coordinates;
        }

        public Vector2Int Value
        {
            get => _coordinates;
            set => _coordinates.Value = value;
        }
    }
}