using System;
using EventBus.Utils;
using UnityEngine;

namespace EventBus.Entities.Common.Model
{
    [Serializable]
    public sealed class Position
    {
        public Transform transform;
        
        public AtomicVariable<Vector2Int> coordinates;   
    }
}