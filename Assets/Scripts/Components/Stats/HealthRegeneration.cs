namespace Components.Stats
{
    public class HealthRegeneration:Statistic
    {
        public HealthRegeneration(float maxValue):base(maxValue)
        {
        }
        
        public void Increase(float value)
        {
            Value += value;
            InvokeOnValueChanged();
        }

        public void Decrease(float value)
        {
            Value -= value;
            InvokeOnValueChanged();
        }
    }
}