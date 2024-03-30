using System;
using Battle.EventBus.Utils;
using UnityEngine;

namespace Battle.EventBus.Entities.Common.Model
{
    [Serializable]
    public sealed class Position
    {
        public Transform transform;

        public AtomicVariable<Vector2Int> coordinates;
    }
}