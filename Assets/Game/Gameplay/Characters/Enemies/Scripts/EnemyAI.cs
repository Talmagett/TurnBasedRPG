using Game.Gameplay.Battle;
using Game.Gameplay.Characters.Scripts;
using UnityEngine;
using Zenject;

namespace Game.Gameplay.Characters.Enemies.Scripts
{
    [RequireComponent(typeof(CharacterEntity))]
    public abstract class EnemyAI : MonoBehaviour
    {
        protected BattleContainer BattleContainer;
        protected CharacterEntity CharacterEntity { get; private set; }
        protected EventBus.EventBus EventBus;
        public void Awake()
        {
            CharacterEntity = GetComponent<CharacterEntity>();
            CharacterEntity.Add(this);
        }

        [Inject]
        public void Ctor(BattleContainer battleContainer,EventBus.EventBus eventBus)
        {
            BattleContainer = battleContainer;
            EventBus = eventBus;
        }

        public abstract void Run();
    }
}