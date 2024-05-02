using System;
using Atomic.Elements;
using UnityEngine;

namespace Battle.Actors.Model
{
    [Serializable]
    public sealed class Position
    {
        public Transform transform;

        public AtomicVariable<Vector2Int> coordinates;
    }
}