using Actors;
using Cysharp.Threading.Tasks;
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
        private DiContainer _diContainer;
        [ReadOnly] [ShowInInspector] public BattleQueue BattleQueue { get; private set; }

        [Inject]
        public void Construct(GameController gameController, DiContainer diContainer)
        {
            _gameController = gameController;
            _diContainer = diContainer;
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
        public void DestroyEnemy(bool isPlayer, BattleActor unit)
        {
            if (isPlayer)
                PlayerSide.DespawnUnit(unit);
            else
                EnemiesSide.DespawnUnit(unit);
            BattleQueue.RemoveUnit(unit);
            BattleQueue.UpdateTime();
        }

        public async void NextTurn()
        {
            while (_gameController.IsBattle)
            {
                BattleQueue.NextTurn();
                await BattleQueue.CurrentCharacter.Run();
            }
        }

        public override async void EnterState()
        {
            base.EnterState();
            PlayerInputActions.Battle.Enable();
            await UniTask.Delay(1000);
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

        public void Setup(BattleActor[] heroes, BattleActor[] enemies, Environment environment)
        {
            BattleQueue = new BattleQueue();

            Instantiate(environment, environmentParent);
            SpawnUnit(true, heroes);
            SpawnUnit(false, enemies);
        }

        public void SpawnUnit(bool isPlayer, params BattleActor[] characters)
        {
            if (isPlayer)
            {
                PlayerSide.SpawnUnits(characters,this);
                BattleQueue.AddUnits(PlayerSide.GetAllCharacters());
            }
            else
            {
                EnemiesSide.SpawnUnits(characters,this);
                BattleQueue.AddUnits(EnemiesSide.GetAllCharacters());
            }
        }

        public BattleActor SpawnUnit(BattleActor character,Transform parent)
        {
            var createdObject = _diContainer.InstantiatePrefab(character, parent);
            return createdObject.GetComponent<BattleActor>();
        }
    }
}