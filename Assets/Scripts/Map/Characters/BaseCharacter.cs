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
        public SharedCharacterStatistics Stats { get; private set; }
        public CharacterConfig GetConfig() => characterConfig;
        
        private void Awake()
        {
            Stats = new SharedCharacterStatistics(characterConfig.Stats);
        }
    }
}