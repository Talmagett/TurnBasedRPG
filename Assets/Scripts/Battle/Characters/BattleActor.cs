using Battle.Actors;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Battle.Characters
{
    [RequireComponent(typeof(ActorData))]
    public abstract class BattleActor : MonoBehaviour
    {
        public ActorData ActorData { get; private set; }

        private UniTaskCompletionSource<bool> _hasFinished;
        protected BattleController BattleController;
        protected EventBus.Game.EventBus EventBus;

        [Inject]
        public void Setup(EventBus.Game.EventBus eventBus, BattleController battleController)
        {
            EventBus = eventBus;
            BattleController = battleController;
            ActorData = GetComponent<ActorData>();
        }

        public abstract UniTask Run();

        public void Finish()
        {
            BattleController.NextTurn();
        }
    }
}