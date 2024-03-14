using Data;
using Game;
using Map.Characters;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Battle
{
    public class BattleController : GameStateController
    {
        [SerializeField] private Transform environmentParent;

        [field: SerializeField] public Side PlayerSide { get; private set; }
        [field: SerializeField] public Side EnemiesSide { get; private set; }

        private GameController _gameController;

        [ReadOnly] [ShowInInspector] public BattleQueue BattleQueue { get; private set; }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space)) NextTurn();
        }

        private void OnEnable()
        {
            PlayerSide.OnUnitsCleared += GameOver;
            EnemiesSide.OnUnitsCleared += FinishBattle;
        }

        private void OnDisable()
        {
            PlayerSide.OnUnitsCleared -= GameOver;
            EnemiesSide.OnUnitsCleared -= FinishBattle;
        }

        [Inject]
        public void Construct(GameController gameController)
        {
            _gameController = gameController;
        }


        private void GameOver()
        {
            _gameController.ExitBattle();
            print("gameOver");
        }

        private void FinishBattle()
        {
            _gameController.ExitBattle();
            print("finish");
        }

        [Button]
        public void DestroyEnemy(bool isPlayer, BaseCharacter unit)
        {
            if (isPlayer)
                PlayerSide.DespawnUnit(unit);
            else
                EnemiesSide.DespawnUnit(unit);
            BattleQueue.RemoveUnit(unit);
            BattleQueue.UpdateTime();
        }

        public void NextTurn()
        {
            BattleQueue.NextTurn();
        }

        public override void EnterState()
        {
            base.EnterState();
            PlayerInputActions.Battle.Enable();
            NextTurn();
        }

        public override void ExitState()
        {
            base.ExitState();
            PlayerInputActions.Battle.Disable();
            while (environmentParent.childCount > 0) DestroyImmediate(environmentParent.GetChild(0).gameObject);
            PlayerSide.ClearField();
            EnemiesSide.ClearField();
        }

        public void Setup(PlayerCharacter[] playerCharacters, EnemyRiftConfig enemyRiftConfig)
        {
            BattleQueue = new BattleQueue();

            Instantiate(enemyRiftConfig.Environment, environmentParent);
            SpawnUnit(true, playerCharacters);
            SpawnUnit(false, enemyRiftConfig.Enemies);
        }

        public void SpawnUnit(bool isPlayer, params BaseCharacter[] characters)
        {
            if (isPlayer)
            {
                PlayerSide.SpawnUnits(characters);
                BattleQueue.AddUnits(PlayerSide.GetAllCharacters());
            }
            else
            {
                EnemiesSide.SpawnUnits(characters);
                BattleQueue.AddUnits(EnemiesSide.GetAllCharacters());
            }
        }
    }
}