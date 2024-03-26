using System.Collections.Generic;
using Actors;
using Battle.Characters;
using Cysharp.Threading.Tasks;
using Data;
using EventBus.Game.Pipeline.Turn;
using Game;
using Map.Characters;
using Sirenix.OdinInspector;
using Sirenix.Utilities;
using UnityEngine;
using Zenject;

namespace Battle
{
    public class BattleController : GameStateController
    {
        [SerializeField] private Transform environmentParent;
        [SerializeField] private Transform playerSideParent;
        [SerializeField] private Transform enemySideParent;

        private Dictionary<Owner, Side> _sides;

        private GameController _gameController;
        private DiContainer _diContainer;
        private TurnPipeline _turnPipeline;

        [ReadOnly] [ShowInInspector] public BattleQueue BattleQueue { get; private set; }

        [Inject]
        public void Construct(GameController gameController, DiContainer diContainer,TurnPipeline turnPipeline)
        {
            _gameController = gameController;
            _diContainer = diContainer;
            _turnPipeline = turnPipeline;
            _sides = new Dictionary<Owner, Side>
            {
                { Owner.Player, new Side(playerSideParent) },
                { Owner.Enemy, new Side(enemySideParent) }
            };
        }

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
        public void DestroyEnemy(Actor unit)
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
            while (_gameController.IsBattle)
            {
                await UniTask.Delay(1000);

                BattleQueue.NextTurn();
                await BattleQueue.CurrentCharacter.Run();
            }
        }

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

        public void SetupEnvironment(Environment environment)
        {
            Instantiate(environment, environmentParent);
        }
        
        public void SetupActors(Actor[] heroes, Actor[] enemies)
        {
            BattleQueue = new BattleQueue();

            SpawnUnit(Owner.Player, heroes);
            SpawnUnit(Owner.Enemy, enemies);
        }

        public void SpawnUnit(Owner owner, params Actor[] characters)
        {
            _sides[owner].SpawnUnits(characters, _diContainer,owner);
            BattleQueue.AddUnits(_sides[owner].GetAllCharacters());
        }
        
        
        public IEnumerable<Actor> GetMyAllies(Owner owner)
        {
            return _sides[owner].GetAllCharacters();
        }

        public Actor GetRandomAlly(Owner owner)
        {
            return _sides[owner].GetRandom();
        }
        
        public IEnumerable<Actor> GetMyEnemies(Owner owner)
        {
            owner = owner == Owner.Enemy ? Owner.Player : Owner.Enemy;
            return _sides[owner].GetAllCharacters();
        }
        
        public Actor GetRandomEnemy(Owner owner)
        {
            owner = owner == Owner.Enemy ? Owner.Player : Owner.Enemy;
            return _sides[owner].GetRandom();
        }
    }
}