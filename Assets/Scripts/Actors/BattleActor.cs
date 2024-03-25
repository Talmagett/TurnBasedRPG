using Battle;
using Battle.Characters;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Actors
{
    public class BattleActor : CharacterActor
    {
        public Actor Actor { get; private set; }
        protected BattleController BattleController;
        private UniTaskCompletionSource<bool> _hasFinished;

        [Inject]
        public void Construct(BattleController battleController)
        {
            BattleController = battleController;
        }

        public void Init(Actor actor)
        {
            Actor = actor;
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