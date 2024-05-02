using Battle.Actors;
using UnityEngine;
using Zenject;

namespace Battle.Characters
{
    [RequireComponent(typeof(ActorData))]
    public abstract class BattleActor : MonoBehaviour
    {
        protected ActorData ActorData { get; private set; }
        protected BattleContainer BattleContainer;
        [Inject]
        public void Ctor(BattleContainer battleContainer)
        {
            BattleContainer = battleContainer;
        }
        public void Awake()
        {
            ActorData = GetComponent<ActorData>();
            ActorData.AddProperty("BattleActor", this);
        }

        public abstract void Run();
    }
}