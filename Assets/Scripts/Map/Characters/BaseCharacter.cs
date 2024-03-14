using Battle.Characters;
using Data;
using UnityEngine;

namespace Map.Characters
{
    public class BaseCharacter : MonoBehaviour, IBattleTurn
    {
        [SerializeField] private CharacterConfig characterConfig;
        [field: SerializeField] public Animator Animator { get; private set; }
        private bool _hasFinished;
        public SharedCharacterStatistics Stats { get; private set; }

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

        public CharacterConfig GetConfig()
        {
            return characterConfig;
        }

        public void DestroySelf()
        {
            //baseCharacter.Animator.SetTrigger("Death");
            Destroy(gameObject);
        }
    }
}