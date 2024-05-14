using Battle;
using UnityEngine;
using Zenject;

namespace Character.Enemies
{
    [RequireComponent(typeof(CharacterEntity))]
    public abstract class EnemyAI : MonoBehaviour
    {
        protected BattleContainer BattleContainer;
        protected CharacterEntity CharacterEntity { get; private set; }

        public void Awake()
        {
            CharacterEntity = GetComponent<CharacterEntity>();
            CharacterEntity.Add(this);
        }

        [Inject]
        public void Ctor(BattleContainer battleContainer)
        {
            BattleContainer = battleContainer;
        }

        public abstract void Run();
    }
}