using System;
using Battle.EventBus.Utils;
using UnityEngine;

namespace Battle.EventBus.Entities.Common.Components
{
    public sealed class HitPointsComponent
    {
        private readonly AtomicVariable<int> _hitPoints;
        private readonly AtomicVariable<int> _maxHitPoints;

        public HitPointsComponent(AtomicVariable<int> hitPoints, AtomicVariable<int> maxHitPoints)
        {
            _hitPoints = hitPoints;
            _maxHitPoints = maxHitPoints;
        }

        public int Value
        {
            get => _hitPoints;
            set => _hitPoints.Value = Mathf.Clamp(value, 0, _maxHitPoints);
        }

        public int MaxHitPoints => _maxHitPoints;

        public event Action<int> OnValueChanged
        {
            add => _hitPoints.ValueChanged += value;
            remove => _hitPoints.ValueChanged -= value;
        }
    }
}