using UnityEngine;

namespace Components.Stats
{
    public class Mana:Statistic
    {
        public float MaxValue { get; protected set; }

        public Mana(float maxValue) : base(maxValue)
        {
            MaxValue = maxValue;
        }

        public void AddMana(float value)
        {
            Value = Mathf.Min(Value + value, MaxValue);
            InvokeOnValueChanged();
        }

        public void ReduceMana(float value)
        {
            Value = Mathf.Max(Value - value, 0);
            InvokeOnValueChanged();
        }
        
        public float GetPercentage()
        {
            return Value / MaxValue;
        }
        
        public bool CanCast(float value) =>  Value >= value;
    }
}