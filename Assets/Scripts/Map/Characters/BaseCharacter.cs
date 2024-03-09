using Data;
using Sirenix.OdinInspector;
using UniRx;
using UnityEngine;

namespace Map.Characters
{
    public class BaseCharacter : MonoBehaviour
    {
        [SerializeField] private CharacterConfig characterConfig;
        [field:SerializeField] public Animator Animator { get; private set; }
        public ReactiveProperty<int> MaxHealth { get; private set; } = new();
        public ReactiveProperty<int> Health { get; private set; } = new();

        public CharacterConfig GetConfig() => characterConfig;
        private void Awake()
        {
            MaxHealth.Value = characterConfig.Stats.Health;
            Health.Value = MaxHealth.Value;
        }
        
        [Button]
        public void ChangeHealth(int value)
        {
            Health.Value += value;
        }
    }
}