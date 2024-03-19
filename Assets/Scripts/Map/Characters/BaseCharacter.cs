using Atomic.Objects;
using Battle.Characters;
using Data;
using UnityEngine;

namespace Map.Characters
{
    public class BaseCharacter : AtomicEntity
    {
        [field: SerializeField] public CharacterConfig CharacterConfig { get; private set; }
        [field: SerializeField] public Animator Animator { get; private set; }
        public SharedCharacterStatistics Stats { get; private set; }
        public IBattleTurn BattleTurn { get; private set; }

        private void Awake()
        {
            Stats = new SharedCharacterStatistics(CharacterConfig.Stats);
            BattleTurn = GetComponent<IBattleTurn>();
            BattleTurn.Init(this);
        }

        public void Select()
        {
            transform.localScale=Vector3.one*1.2f;
        }

        public void Deselect()
        {
            transform.localScale=Vector3.one;
        }
        
        public void DestroySelf()
        {
            //baseCharacter.Animator.SetTrigger("Death");
            Destroy(gameObject);
        }
    }
}