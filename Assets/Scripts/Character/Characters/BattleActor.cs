using Battle.Actors;
using UnityEngine;
using Zenject;

namespace Battle.Characters
{
    [RequireComponent(typeof(CharacterEntity))]
    public abstract class BattleActor : MonoBehaviour
    {
        protected CharacterEntity CharacterEntity { get; private set; }
        protected BattleContainer BattleContainer;
        [Inject]
        public void Ctor(BattleContainer battleContainer)
        {
            BattleContainer = battleContainer;
        }
        public void Awake()
        {
            CharacterEntity = GetComponent<CharacterEntity>();
            CharacterEntity.Add(this);
        }

        public abstract void Run();
    }
}