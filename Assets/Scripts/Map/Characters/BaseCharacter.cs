using Battle.Characters;
using Data;
using Sirenix.OdinInspector;
using UniRx;
using UnityEngine;

namespace Map.Characters
{
    public class BaseCharacter : MonoBehaviour, IBattleTurn
    {
        [SerializeField] private CharacterConfig characterConfig;
        [field:SerializeField] public Animator Animator { get; private set; }
        public SharedCharacterStatistics Stats { get; private set; }
        public CharacterConfig GetConfig() => characterConfig;
        private bool _hasFinished;
        private void Awake()
        {
            Stats = new SharedCharacterStatistics(characterConfig.Stats);
        }

        public void StartTurn()
        {
            _hasFinished = false;
        }

        public bool HasFinished()
        {
            return _hasFinished;
        }

        public void EndTurn()
        {
            _hasFinished = true;
        }

        public void DestroySelf()
        {
            //baseCharacter.Animator.SetTrigger("Death");
            Destroy(gameObject);
        }
    }
}