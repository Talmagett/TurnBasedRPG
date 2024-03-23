using Atomic.Elements;
using Atomic.Objects;
using Battle.Characters;
using Data;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Map.Characters
{
    public class BaseCharacter : AtomicEntity
    {
        public AtomicVariable<Animator> animator;
        public AtomicVariable<CharacterConfig> characterConfig;
        [ReadOnly] public AtomicVariable<SharedCharacterStatistics> stats;
        
        [SerializeField] private AtomicVariable<float> collisionRadius;
        public IBattleTurn BattleTurn { get; private set; }
        public bool IsDead { get; private set; }
        private bool _isInited;
        public void InitStats(CharacterStatistic statsData)
        {
            stats.Value.Init(statsData);
            _isInited = true;
        }
        
        private void Awake()
        {
            BattleTurn = GetComponent<IBattleTurn>();
            BattleTurn.Init(this);
            AddProperty("CollisionRadius", collisionRadius);
            AddProperty("Transform", transform);
            if(!_isInited)
                InitStats(characterConfig.Value.Stats);
        }

        public void Select()
        {
            transform.localScale=Vector3.one*1.2f;
        }

        public void Deselect()
        {
            transform.localScale=Vector3.one;
        }

        public void TakeDamage(int damage)
        {
            stats.Value.health.Value -= damage;
            if (stats.Value.health.Value <= 0)
                IsDead = true;
        }

        public void DestroySelf()
        {
            //baseCharacter.Animator.SetTrigger("Death");
            Destroy(gameObject);
        }
    }
}