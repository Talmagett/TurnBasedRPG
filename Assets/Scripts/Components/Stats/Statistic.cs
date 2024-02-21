using System;

namespace Components.Stats
{
    public abstract class Statistic
    {
        public event Action<float> OnValueChanged;
        protected float Value { get; set; }

        protected Statistic(float baseValue)
        {
            Value = baseValue;
        }

        protected void InvokeOnValueChanged()
        {
            OnValueChanged?.Invoke(Value);
        }
    }
}