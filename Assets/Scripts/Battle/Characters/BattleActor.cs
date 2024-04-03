using Battle.Actors;
using Cysharp.Threading.Tasks;
using UnityEngine;
using Zenject;

namespace Battle.Characters
{
    [RequireComponent(typeof(ActorData))]
    public abstract class BattleActor : MonoBehaviour
    {
        private UniTaskCompletionSource<bool> _hasFinished;
        public ActorData ActorData { get; private set; }

        public void Awake()
        {
            ActorData = GetComponent<ActorData>();
        }

        public abstract void Run();
    }
}