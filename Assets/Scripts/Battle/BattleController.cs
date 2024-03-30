using System.Collections.Generic;
using Battle.Actors;
using Battle.EventBus.Game.Pipeline.Turn;
using Game;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Battle
{
    public class BattleController : MonoBehaviour
    {
        [SerializeField] private Transform environmentParent;
        [SerializeField] private Transform playerSideParent;
        [SerializeField] private Transform enemySideParent;
        private DiContainer _diContainer;

        private GameStateController _gameStateController;

        private Dictionary<Owner, Side> _sides;
        private TurnPipeline _turnPipeline;

        [ReadOnly] [ShowInInspector] public BattleQueue BattleQueue { get; private set; }

        private void OnEnable()
        {
            _sides[Owner.Player].OnUnitsCleared += GameOver;
            _sides[Owner.Enemy].OnUnitsCleared += FinishBattle;
        }

        private void OnDisable()
        {
            _sides[Owner.Player].OnUnitsCleared -= GameOver;
            _sides[Owner.Enemy].OnUnitsCleared -= FinishBattle;
        }

        [Inject]
        public void Construct(GameStateController gameStateController, DiContainer diContainer,
            TurnPipeline turnPipeline)
        {
            _gameStateController = gameStateController;
            _diContainer = diContainer;
            _turnPipeline = turnPipeline;
            _sides = new Dictionary<Owner, Side>
            {
                { Owner.Player, new Side(playerSideParent) },
                { Owner.Enemy, new Side(enemySideParent) }
            };
        }

        private void GameOver()
        {
            _gameStateController.ExitBattle();
            print("gameOver");
        }

        private void FinishBattle()
        {
            _gameStateController.ExitBattle();
            print("finish");
        }

        [Button]
        public void DestroyEnemy(ActorData unit)
        {
            _sides[unit.Owner].DespawnUnit(unit);
            BattleQueue.RemoveUnit(unit);
            BattleQueue.UpdateTime();
        }

        public void Run()
        {
            _turnPipeline.Run();
        }

        public async void NextTurn()
        {
            /*while (_gameStateController.IsBattle)
            {
                await UniTask.Delay(1000);

                BattleQueue.NextTurn();
                //await BattleQueue.CurrentCharacter.Run();
            }*/
        }

/*
        public override void EnterState()
        {
            base.EnterState();
            PlayerInputActions.Battle.Enable();
            BattleQueue.UpdateTime();
            NextTurn();
        }

        public override void ExitState()
        {
            base.ExitState();
            PlayerInputActions.Battle.Disable();
            while (environmentParent.childCount > 0) DestroyImmediate(environmentParent.GetChild(0).gameObject);
            _sides.ForEach(t => t.Value.ClearField());
        }
*/
        public void SetupEnvironment(Environment environment)
        {
            Instantiate(environment, environmentParent);
        }

        public void SetupActors(ActorData[] heroes, ActorData[] enemies)
        {
            BattleQueue = new BattleQueue();

            SpawnUnit(Owner.Player, heroes);
            SpawnUnit(Owner.Enemy, enemies);
        }

        public void SpawnUnit(Owner owner, params ActorData[] characters)
        {
            _sides[owner].SpawnUnits(characters, _diContainer, owner);
            BattleQueue.AddUnits(_sides[owner].GetAllCharacters());
        }


        public IEnumerable<ActorData> GetMyAllies(Owner owner)
        {
            return _sides[owner].GetAllCharacters();
        }

        public ActorData GetRandomAlly(Owner owner)
        {
            return _sides[owner].GetRandom();
        }

        public IEnumerable<ActorData> GetMyEnemies(Owner owner)
        {
            owner = owner == Owner.Enemy ? Owner.Player : Owner.Enemy;
            return _sides[owner].GetAllCharacters();
        }

        public ActorData GetRandomEnemy(Owner owner)
        {
            owner = owner == Owner.Enemy ? Owner.Player : Owner.Enemy;
            return _sides[owner].GetRandom();
        }
    }
}