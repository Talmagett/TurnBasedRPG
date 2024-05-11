using System;
using System.Collections.Generic;
using System.Linq;
using Atomic.Elements;
using Battle.Actors;
using Battle.Actors.Model;
using Battle.Characters;
using Configs;
using Configs.Enums;
using Cysharp.Threading.Tasks;
using EventBus.Events;
using Game;
using Game.Heroes;
using PrimeTween;
using Sirenix.OdinInspector;
using Sirenix.Utilities;
using UI.Views;
using UnityEngine;
using Visual.UI;
using Zenject;
using Random = UnityEngine.Random;

namespace Battle
{
    public class BattleController : MonoBehaviour
    {
        //TODO: add UI to battle state changed
        public event Action<BattleState> OnStateChanged;

        public enum BattleState
        {
            Going,
            Exit,
            Win,
            Lose
        }

        [Title("Configs")] 
        [SerializeField] private Transform environmentParent;

        private BattleState _battleState;

        private DiContainer _diContainer;

        private HeroParty _heroParty;
        private BattleContainer _battleContainer;
        private UIController _uiController;

        private void OnEnable()
        {
            _battleContainer.OnUnitsCleared += OnBattleFinished;
        }

        private void OnDisable()
        {
            _battleContainer.OnUnitsCleared -= OnBattleFinished;
        }

        [Inject]
        public void Construct(DiContainer diContainer)
        {
            _diContainer = diContainer;
            _battleContainer = _diContainer.Resolve<BattleContainer>();
            _heroParty = _diContainer.Resolve<HeroParty>();
            _uiController = _diContainer.Resolve<UIController>();
        }

        private void OnBattleFinished(Owner owner)
        {
            _battleState = owner==Owner.Enemy?BattleState.Win:BattleState.Lose;
            OnStateChanged?.Invoke(_battleState);
        }

        public void ExitBattle()
        {
            _battleState = BattleState.Exit;
            OnStateChanged?.Invoke(_battleState);
        }

        /*private void FinishBattle()
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

//            BattleQueue.Clear();
        }*/

        public void SetupBattle(EnemyRiftConfig enemyRiftConfig)
        {
            _battleState = BattleState.Going;
            OnStateChanged?.Invoke(_battleState);
            var environment = Instantiate(enemyRiftConfig.Environment, environmentParent);

            for (var i = 0; i < _heroParty.HeroDataArray.Length; i++)
            {
                var unitData = _heroParty.HeroDataArray[i];
                var position = -(_heroParty.HeroDataArray.Length - 1) / 2f + i;
                var unit = SpawnUnit(unitData.Prefab, environment.PlayerSpawnPosition,Owner.Player, unitData.Name, unitData.CharacterConfig.Icon,
                    unitData.Stats.GetAllStats());
                unit.transform.position += Vector3.forward*position*2;
                _battleContainer.AddUnit(unit);
            }

            for (var i = 0; i < enemyRiftConfig.Enemies.Length; i++)
            {
                var unitData = enemyRiftConfig.Enemies[i];
                var position = -(enemyRiftConfig.Enemies.Length - 1) / 2f + i;
                var unit = SpawnUnit(unitData.Prefab,environment.EnemySpawnPosition ,Owner.Enemy, unitData.Name, unitData.Icon,
                    unitData.Stats.CloneStats());
                unit.transform.position += Vector3.forward*position*2;
                _battleContainer.AddUnit(unit);
            }

            Tween.Delay(1).OnComplete(() =>
            {
                _uiController.Close();
                EventBus.EventBus.RaiseEvent(new NextTurnEvent());
            });
        }

        private ActorData SpawnUnit(ActorData prefab, Transform parent, Owner owner, string characterName, Sprite icon, Dictionary<StatKey, float> stats)
        {
            var actorData = _diContainer.InstantiatePrefab(prefab,parent).GetComponent<ActorData>();
            actorData.AddProperty(AtomicAPI.Owner,new Ownership(owner));
            actorData.AddProperty(AtomicAPI.Name, characterName);
            var attack = new Attack
            {
                energy = new AtomicVariable<int>(Random.Range(0, 6))
            };
            actorData.AddProperty(AtomicAPI.Attack, attack);
            actorData.AddProperty(AtomicAPI.SharedStats, new SharedCharacterStats(stats));
            //actorData.AddProperty(AtomicAPI.Description, "Description Lores Insum");
            //actorData.AddProperty(AtomicAPI.Icon, icon);
            return actorData;
        }
    }
}