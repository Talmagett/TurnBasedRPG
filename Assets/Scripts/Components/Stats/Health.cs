using System;
using UnityEngine;

namespace Components.Stats
{
    public class Health : Statistic
    {
        public float MaxValue { get; protected set; }
        
        public Health(float maxValue) : base(maxValue)
        {
            InvokeOnValueChanged();
        }
        
        public void TakeDamage(float damage)
        {
            Value = Mathf.Max(Value - damage, 0);
            InvokeOnValueChanged();
        }

        public void Heal(float value)
        {
            Value = Mathf.Min(Value + value, MaxValue);
            InvokeOnValueChanged();
        }

        public float GetPercentage()=> Value / MaxValue;

        public bool CanKill(float value) => Value < value;
    }
}