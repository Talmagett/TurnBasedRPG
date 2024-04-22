using System;
using System.Collections.Generic;
using System.Linq;
using Battle.Actors;
using Battle.Characters;
using Battle.EventBus.Game.Pipeline.Turn;
using Configs;
using Configs.Enums;
using Cysharp.Threading.Tasks;
using Game;
using Game.Heroes;
using PrimeTween;
using Sirenix.OdinInspector;
using Sirenix.Utilities;
using UnityEngine;
using Visual.UI;
using Zenject;

namespace Battle
{
    public class BattleController : MonoBehaviour
    {
        [Title("Configs")] [SerializeField] private Transform environmentParent;

        [SerializeField] private Transform playerSideParent;
        [SerializeField] private Transform enemySideParent;

        private DiContainer _diContainer;

        private GameStateController _gameStateController;
        private HeroParty _heroParty;

        private Dictionary<Owner, Side> _sides;
        private TurnPipeline _turnPipeline;
        [ReadOnly] [ShowInInspector] public BattleQueue BattleQueue { get; private set; }

        private BattleState _battleState;
        private UIController _uiController;

        public event Action<BattleState> OnStateChanged;
        //TODO: add UI to battle state changed
        public enum BattleState
        {
            Going,
            Exit,
            Win,
            Lose
        }

        private void OnEnable()
        {
            _sides[Owner.Player].OnUnitsCleared += GameOver;
            _sides[Owner.Enemy].OnUnitsCleared += WinBattle;
        }

        private void OnDisable()
        {
            _sides[Owner.Player].OnUnitsCleared -= GameOver;
            _sides[Owner.Enemy].OnUnitsCleared -= WinBattle;
        }

        [Inject]
        public void Construct(DiContainer diContainer)
        {
            _diContainer = diContainer;
            _gameStateController = _diContainer.Resolve<GameStateController>();
            _turnPipeline = _diContainer.Resolve<TurnPipeline>();
            _heroParty = _diContainer.Resolve<HeroParty>();
            _uiController = _diContainer.Resolve<UIController>();
            BattleQueue = new BattleQueue(this);
            _sides = new Dictionary<Owner, Side>
            {
                { Owner.Player, new Side(playerSideParent) },
                { Owner.Enemy, new Side(enemySideParent) }
            };
        }

        private void WinBattle()
        {
            _battleState = BattleState.Win;
            OnStateChanged?.Invoke(_battleState);
        }

        private void GameOver()
        {
            _battleState = BattleState.Lose;
            OnStateChanged?.Invoke(_battleState);
        }

        public void ExitBattle()
        {
            _battleState = BattleState.Exit;
            OnStateChanged?.Invoke(_battleState);
        }

        private void FinishBattle()
        {
            _gameStateController.ExitBattle();

            foreach (var heroActor in _sides[Owner.Player].GetAllCharacters())
            {
                var heroData = _heroParty.HeroDataArray.FirstOrDefault(t => t.ID == heroActor.ID);
                if (heroData == null) continue;
                
                heroData.Stats.SetStat(StatKey.Health,
                    Mathf.Max(1, heroActor.SharedStats.GetStat(StatKey.Health).Value));
                heroData.Stats.SetStat(StatKey.Mana, heroActor.SharedStats.GetStat(StatKey.Mana).Value);
            }

            BattleQueue.Clear();
        }

        [Button]
        public void DestroyEnemy(ActorData unit)
        {
            _sides[unit.Owner].DespawnUnit(unit);
            BattleQueue.RemoveUnit(unit.GetComponent<BattleActor>());
        }

        public void Run()
        {
            _turnPipeline.Run();
        }

        public async void NextTurn()
        {
            await UniTask.Delay(500);
            
            if (_battleState!= BattleState.Going)
            {
                FinishBattle();
                return;
            }

            BattleQueue.NextTurn();
        }

        public void ClearBattle()
        {
            while (environmentParent.childCount > 0) DestroyImmediate(environmentParent.GetChild(0).gameObject);
            _sides.ForEach(t => t.Value.ClearField());
        }

        public void SetupBattle(EnemyRiftConfig enemyRiftConfig)
        {
            _battleState = BattleState.Going;
            OnStateChanged?.Invoke(_battleState);
            Instantiate(enemyRiftConfig.Environment, environmentParent);

            for (var i = 0; i < _heroParty.HeroDataArray.Length; i++)
            {
                var unitData = _heroParty.HeroDataArray[i];
                var position = -(_heroParty.HeroDataArray.Length - 1) / 2f + i;
                var unit = SpawnUnit(unitData.Prefab, Owner.Player, unitData.ID, unitData.Icon,
                    unitData.Stats.GetAllStats(), position);
            }

            for (var i = 0; i < enemyRiftConfig.Enemies.Length; i++)
            {
                var unitData = enemyRiftConfig.Enemies[i];
                var position = -(enemyRiftConfig.Enemies.Length - 1) / 2f + i;
                var unit = SpawnUnit(unitData.Prefab, Owner.Enemy, unitData.ID, unitData.Icon,
                    unitData.Stats.CloneStats(), position);
            }

            BattleQueue.AddUnits(_sides[Owner.Player].GetAllCharacters().Select(t => t.GetComponent<BattleActor>()));
            BattleQueue.AddUnits(_sides[Owner.Enemy].GetAllCharacters().Select(t => t.GetComponent<BattleActor>()));

            Tween.Delay(1).OnComplete(()=>{
                _uiController.Close();
                NextTurn();
            });

        }

        private ActorData SpawnUnit(ActorData prefab, Owner owner, string id, Sprite icon,
            Dictionary<StatKey, float> stats, float position)
        {
            var actorData = _diContainer.InstantiatePrefab(prefab).GetComponent<ActorData>();
            actorData.InitStats(stats);

            actorData.SetOwner(owner);
            actorData.Setup(id, icon);
            _sides[owner].SetupUnit(actorData, position);

            return actorData;
        }

        //_______________________________
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