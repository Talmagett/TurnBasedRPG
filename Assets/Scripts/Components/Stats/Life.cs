using System;

namespace Components.Stats
{
    public class Life : IDisposable
    {
        private readonly bool _canBeRevived;
        private readonly Health _health;
        public event Action OnDie;
        public event Action OnRevived;
        
        public bool IsDead { get; private set; }

        public Life(bool canBeRevived, Health health)
        {
            _canBeRevived = canBeRevived;
            _health = health;
            _health.OnValueChanged += CheckHealth;
        }

        private void CheckHealth(float healthValue)
        {
            if (IsDead)
                return;
            
            if (!(healthValue <= 0)) 
                return;
            
            IsDead = true;
            OnDie?.Invoke();
        }

        public void Revive(float health)
        {
            if (!_canBeRevived)
                return;

            IsDead = false;
            _health.Heal(health);
            OnRevived?.Invoke();
        }
        
        public void Dispose()
        {
            _health.OnValueChanged -= CheckHealth;
        }
    }
}