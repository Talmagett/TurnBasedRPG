using System;
using Game.Data;
using Sirenix.OdinInspector;
using UniRx;
using UnityEngine;

namespace Game.Map.Scripts
{
    public class BaseCharacter : MonoBehaviour
    {
        [SerializeField] private CharacterConfig characterConfig;
        public ReactiveProperty<int> MaxHealth { get; private set; } = new();
        public ReactiveProperty<int> Health { get; private set; } = new();

        private void Awake()
        {
            MaxHealth.Value = characterConfig.Health;
            Health.Value = MaxHealth.Value;
        }
        
        [Button]
        public void ChangeHealth(int value)
        {
            Health.Value += value;
        }
    }
}