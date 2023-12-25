using System;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Serialization;

namespace Components
{
    public class Health : MonoBehaviour
    {
        public event Action<float> OnHealthChangedPercentage;
        [Min(1)]
        [SerializeField] private int maxHealth;
        [ReadOnly][ShowInInspector]
        private float _currentHealth;

        public int GetMissingHealth()
        {
            return (int)(maxHealth - _currentHealth);
        }

        public int GetMaxHealth()
        {
            return maxHealth;
        }

        private void Start()
        {
            _currentHealth = maxHealth;
            OnHealthChangedPercentage?.Invoke(_currentHealth / maxHealth);
        }

        public void TakeDamage(float damage)
        {
            _currentHealth = Mathf.Max(_currentHealth - damage, 0);
            OnHealthChangedPercentage?.Invoke(_currentHealth / maxHealth);
            if (_currentHealth == 0)
            {
                Die();
            }
        }

        public void Heal(float value)
        {
            _currentHealth = Mathf.Min(_currentHealth + value, maxHealth);
            OnHealthChangedPercentage?.Invoke(_currentHealth / maxHealth);
        }

        private void Die()
        {
            Destroy(gameObject);
        }
    }
}