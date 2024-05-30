using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;
using Game.Gameplay.Characters.Scripts;
using Game.Gameplay.Characters.Scripts.Components;
using Game.Gameplay.Characters.Scripts.Keys;
using Game.Gameplay.Characters.Scripts.SO;
using Game.Gameplay.Environment.Scripts;
using Game.Gameplay.EventBus.Events;
using Game.Gameplay.Game.Heroes;
using PrimeTween;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Game.Gameplay.Battle
{
    public class BattleController : MonoBehaviour
    {
        public enum BattleState
        {
            Going,
            Exit,
            Win,
            Lose
        }

        [Title("Configs")] [SerializeField] private Transform environmentParent;
        
        private BattleState _battleState;
        private BattleContainer _battleContainer;
        private DiContainer _diContainer;
        private HeroParty _heroParty;
        
        public event Action<BattleState> OnStateChanged;

        [Inject]
        public void Construct(DiContainer diContainer)
        {
            _diContainer = diContainer;
            _battleContainer = _diContainer.Resolve<BattleContainer>();
            _heroParty = _diContainer.Resolve<HeroParty>();
        }
        
        private void OnEnable()
        {
            _battleContainer.OnUnitsCleared += OnBattleFinished;
        }

        private void OnDisable()
        {
            _battleContainer.OnUnitsCleared -= OnBattleFinished;
        }

        private void OnBattleFinished(Owner owner)
        {
            _battleState = owner == Owner.Enemy ? BattleState.Win : BattleState.Lose;
            FinishBattle().Forget();
        }

        private async UniTask FinishBattle()
        {
            await UniTask.Delay(1000);
            OnStateChanged?.Invoke(_battleState);
        }

        public async UniTask ClearBattle()
        {
            await UniTask.Delay(1000);
            while (environmentParent.childCount > 0) DestroyImmediate(environmentParent.GetChild(0).gameObject);
        }

        public void SetupBattle(EnemyRiftConfig enemyRiftConfig)
        {
            _battleState = BattleState.Going;
            OnStateChanged?.Invoke(_battleState);
            var environment = Instantiate(enemyRiftConfig.Environment, environmentParent);

            for (var i = 0; i < _heroParty.HeroDataArray.Length; i++)
            {
                var unitData = _heroParty.HeroDataArray[i];
                var position = -(_heroParty.HeroDataArray.Length - 1) / 2f + i;
                var characterConfig = unitData.Get<HeroCharacterConfig>();
                var unit = SpawnUnit(characterConfig.Prefab, environment.PlayerSpawnPosition);
                unit.AddRange(characterConfig.CloneComponents());
                unit.Add(characterConfig);
                unit.transform.position += Vector3.forward * position * 2;
                _battleContainer.AddUnit(unit);
            }

            for (var i = 0; i < enemyRiftConfig.Enemies.Length; i++)
            {
                var unitData = enemyRiftConfig.Enemies[i];
                var position = -(enemyRiftConfig.Enemies.Length - 1) / 2f + i;
                var unit = SpawnUnit(unitData.Prefab, environment.EnemySpawnPosition);
                unit.AddRange(unitData.CloneComponents());
                unit.transform.position += Vector3.forward * position * 2;
                _battleContainer.AddUnit(unit);
            }

            Tween.Delay(1).OnComplete(() => { EventBus.EventBus.RaiseEvent(new NextTurnEvent()); });
        }

        private CharacterEntity SpawnUnit(CharacterEntity prefab, Transform parent)
        {
            var actorData = _diContainer.InstantiatePrefab(prefab, parent).GetComponent<CharacterEntity>();
            //actorData.Add(new Component_Turn(Random.Range(1, 6)));
            //actorData.AddProperty(AtomicAPI.Description, "Description Lores Insum");
            //actorData.AddProperty(AtomicAPI.Icon, icon);
            return actorData;
        }
    }
}