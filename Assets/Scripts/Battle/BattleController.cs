using System.Collections.Generic;
using System.Linq;
using Battle.Actors;
using Battle.Characters;
using Battle.EventBus.Game.Pipeline.Turn;
using Configs;
using Configs.Character;
using Configs.Enums;
using Cysharp.Threading.Tasks;
using Game;
using Game.Heroes;
using Sirenix.OdinInspector;
using Sirenix.Utilities;
using UnityEngine;
using UnityEngine.Serialization;
using Zenject;

namespace Battle
{
    public class BattleController : MonoBehaviour
    {
        [ReadOnly] [ShowInInspector] public BattleQueue BattleQueue { get; private set; }
        [Title("Configs")]
        [SerializeField] private Transform environmentParent;
        [SerializeField] private Transform playerSideParent;
        [SerializeField] private Transform enemySideParent;
        
        [Space] [SerializeField] private HeroAbilitiesPresenter heroAbilitiesPresenter;
        
        private DiContainer _diContainer;

        private GameStateController _gameStateController;
        private HeroParty _heroParty;
        
        private Dictionary<Owner, Side> _sides;
        private TurnPipeline _turnPipeline;
        
        private bool _isBattle;
        
        [Inject]
        public void Construct(DiContainer diContainer)
        {
            _diContainer = diContainer;
            _gameStateController = _diContainer.Resolve<GameStateController>();
            _turnPipeline = _diContainer.Resolve<TurnPipeline>();
            _heroParty = _diContainer.Resolve<HeroParty>();
            _sides = new Dictionary<Owner, Side>
            {
                { Owner.Player, new Side(playerSideParent) },
                { Owner.Enemy, new Side(enemySideParent) }
            };
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

        private void WinBattle()
        {
            print("win");
            FinishBattle();
        }

        private void GameOver()
        {
            print("gameOver");
            FinishBattle();
        }

        private void FinishBattle()
        {
            _gameStateController.ExitBattle();
            
            foreach (var heroActor in _sides[Owner.Player].GetAllCharacters())
            {
                var heroData = _heroParty.HeroDataArray.FirstOrDefault(t=>t.ID==heroActor.ID);
                heroData.Stats.SetStat(StatKey.Health,Mathf.Max(1,heroActor.SharedStats.GetStat(StatKey.Health)));
                heroData.Stats.SetStat(StatKey.Mana,heroActor.SharedStats.GetStat(StatKey.Mana));
            }
            print("finish");
            _isBattle = false;
            BattleQueue.Dispose();
        }

        [Button]
        public void DestroyEnemy(BattleActor unit)
        {
            _sides[unit.ActorData.Owner].DespawnUnit(unit.ActorData);
            BattleQueue.RemoveUnit(unit);
            BattleQueue.UpdateTime();
        }

        public void Run()
        {
            _turnPipeline.Run();
        }

        public async void NextTurn()
        {
                await UniTask.Delay(500);

                BattleQueue.NextTurn();
                heroAbilitiesPresenter.Clear();

                if (BattleQueue.CurrentCharacter.ActorData.Owner == Owner.Player)
                {
                    heroAbilitiesPresenter.SetHero(BattleQueue.CurrentCharacter.ActorData);
                }
                
                await BattleQueue.CurrentCharacter.Run();
        }

        public void Clear()
        {
            while (environmentParent.childCount > 0) DestroyImmediate(environmentParent.GetChild(0).gameObject);
            _sides.ForEach(t => t.Value.ClearField());
        }
        
        public void Setup(EnemyRiftConfig enemyRiftConfig)
        {
            Instantiate(enemyRiftConfig.Environment, environmentParent);
            BattleQueue = new BattleQueue();
            
            _isBattle = true;
            for (int i = 0; i < _heroParty.HeroDataArray.Length; i++)
            {
                var unitData = _heroParty.HeroDataArray[i];
                var position = -(_heroParty.HeroDataArray.Length - 1) / 2f + i;
                var unit = SpawnUnit(unitData.Prefab,Owner.Player,unitData.ID,unitData.Icon,unitData.Stats.GetAllStats(),position);
            }

            for (int i = 0; i < enemyRiftConfig.Enemies.Length; i++)
            {
                var unitData = enemyRiftConfig.Enemies[i];
                var position = -(enemyRiftConfig.Enemies.Length - 1) / 2f + i;
                var unit = SpawnUnit(unitData.Prefab,Owner.Enemy,unitData.ID,unitData.Icon,unitData.Stats.CloneStats(),position);
            }
            
            BattleQueue.AddUnits(_sides[Owner.Player].GetAllCharacters().Select(t=>t.GetComponent<BattleActor>()));
            BattleQueue.AddUnits(_sides[Owner.Enemy].GetAllCharacters().Select(t=>t.GetComponent<BattleActor>()));

            BattleQueue.UpdateTime();
            NextTurn();
        }

        private ActorData SpawnUnit(ActorData prefab, Owner owner, string id, Sprite icon, Dictionary<StatKey,float> stats,float position)
        {
            var actorData = _diContainer.InstantiatePrefab(prefab).GetComponent<ActorData>();
            
            actorData.SetOwner(owner);
            actorData.Setup(id,icon);
            actorData.InitStats(stats);
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