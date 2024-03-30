using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Battle.EventBus.Utils
{
    [Serializable]
    public class AtomicVariable<T>
    {
        [OnValueChanged("OnValueChangedInEditor")] [SerializeField]
        private T value;

        public AtomicVariable()
        {
            value = default;
        }

        public AtomicVariable(T value)
        {
            this.value = value;
        }

        public AtomicEvent<T> ValueChanged { get; set; } = new();

        public T Value
        {
            get => value;
            set => SetValue(value);
        }

        public static implicit operator T(AtomicVariable<T> value)
        {
            return value.value;
        }

        public static implicit operator AtomicVariable<T>(T value)
        {
            return new AtomicVariable<T>(value);
        }

        protected virtual void SetValue(T value)
        {
            this.value = value;
            ValueChanged?.Invoke(value);
        }

#if UNITY_EDITOR
        private void OnValueChangedInEditor(T _)
        {
            ValueChanged?.Invoke(value);
        }
#endif
    }
}