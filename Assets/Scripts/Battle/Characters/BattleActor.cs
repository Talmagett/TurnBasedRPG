using Battle.Actors;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Battle.Characters
{
    public class BattleActor : MonoBehaviour
    {
        [field: SerializeField] public ActorData ActorData { get; private set; }

        private UniTaskCompletionSource<bool> _hasFinished;
        protected BattleController BattleController;
        protected EventBus.Game.EventBus EventBus;

        [Inject]
        public void Setup(EventBus.Game.EventBus eventBus, BattleController battleController)
        {
            EventBus = eventBus;
            BattleController = battleController;
        }

        public virtual async UniTask Run()
        {
            await UniTask.Delay(1000);
        }
    }
}