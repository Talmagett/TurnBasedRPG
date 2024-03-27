using Atomic.Elements;
using Atomic.Objects;
using Battle;
using Battle.Characters;
using Cysharp.Threading.Tasks;
using Data;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Actors
{
    public class Actor : AtomicObject
    {
        [field: SerializeField] public CharacterConfig Config { get; private set; }
        [field: SerializeField] public Animator Animator { get; private set; }
    
        public Owner Owner { get; private set; }
        [ReadOnly]
        public SharedCharacterStatistics stats;
        private UniTaskCompletionSource<bool> _hasFinished;
        protected EventBus.Game.EventBus EventBus;
        protected BattleController BattleController;
        
        public void Init(EventBus.Game.EventBus eventBus, BattleController battleController,Owner owner)
        {
            EventBus = eventBus;
            BattleController = battleController;
            stats.Init(Config.stats);
            Owner = owner;
        }
        
        public virtual void Awake()
        {
            AddProperty("Transform", transform);
            AddProperty("GameObject", gameObject);
            AddProperty("Stats", stats);
        }
        
        public void Select()
        {
            transform.localScale = Vector3.one * 1.2f;
        }

        public void Deselect()
        {
            transform.localScale = Vector3.one;
        }

        public virtual async UniTask Run()
        {
            await UniTask.Delay(1000);
        }

        public void DestroySelf()
        {
            Destroy(gameObject);
        }
    }
}