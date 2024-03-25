using Atomic.Elements;
using Battle;
using Cysharp.Threading.Tasks;
using Data;
using UnityEngine;
using Zenject;

namespace Actors
{
    public abstract class BattleActor: Entity
    {        
        [SerializeField] private AtomicVariable<Animator> animator;
        public AtomicVariable<SharedCharacterStatistics> stats;
        
        protected BattleController BattleController;

        private UniTaskCompletionSource<bool> _hasFinished;
            
        [Inject]
        public void Construct(BattleController battleController)
        {
            BattleController = battleController;
        }
        
        public override void Awake() 
        {
            base.Awake();
            AddProperty("Animator", animator);
        }
        
        public void Select()
        {
            transform.localScale=Vector3.one*1.2f;
        }

        public void Deselect()
        {
            transform.localScale=Vector3.one;
        }

        public abstract UniTask Run();
        
        public void DestroySelf()
        {
            Destroy(gameObject);
        }
    }
}