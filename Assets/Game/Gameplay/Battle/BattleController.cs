using System;
using System.Collections.Generic;
using Game.Configs.Configs;
using Game.Configs.Configs.Character;
using Game.Configs.Configs.Enums;
using Game.Gameplay.Characters.Scripts;
using Game.Gameplay.Characters.Scripts.Components;
using Game.Gameplay.EventBus.Events;
using Game.Gameplay.Game.Heroes;
using PrimeTween;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

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

        private BattleContainer _battleContainer;

        private BattleState _battleState;

        private DiContainer _diContainer;

        private HeroParty _heroParty;

        private void OnEnable()
        {
            _battleContainer.OnUnitsCleared += OnBattleFinished;
        }

        private void OnDisable()
        {
            _battleContainer.OnUnitsCleared -= OnBattleFinished;
        }

        //TODO: add UI to battle state changed
        public event Action<BattleState> OnStateChanged;

        [Inject]
        public void Construct(DiContainer diContainer)
        {
            _diContainer = diContainer;
            _battleContainer = _diContainer.Resolve<BattleContainer>();
            _heroParty = _diContainer.Resolve<HeroParty>();
        }

        private void OnBattleFinished(Owner owner)
        {
            _battleState = owner == Owner.Enemy ? BattleState.Win : BattleState.Lose;
            OnStateChanged?.Invoke(_battleState);
        }

        public void ExitBattle()
        {
            ClearBattle();
            _battleState = BattleState.Exit;
            OnStateChanged?.Invoke(_battleState);
        }

        public void ClearBattle()
        {
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
                var unit = SpawnUnit(characterConfig.Prefab, environment.PlayerSpawnPosition, Owner.Player,
                    characterConfig.Name,
                    unitData.Get<SharedCharacterStats>().GetAllStats());
                unit.Add(characterConfig);
                unit.transform.position += Vector3.forward * position * 2;
                _battleContainer.AddUnit(unit);
            }

            for (var i = 0; i < enemyRiftConfig.Enemies.Length; i++)
            {
                var unitData = enemyRiftConfig.Enemies[i];
                var position = -(enemyRiftConfig.Enemies.Length - 1) / 2f + i;
                var unit = SpawnUnit(unitData.Prefab, environment.EnemySpawnPosition, Owner.Enemy, unitData.Name,
                    unitData.Stats.CloneStats());
                unit.transform.position += Vector3.forward * position * 2;
                _battleContainer.AddUnit(unit);
            }

            Tween.Delay(1).OnComplete(() => { EventBus.EventBus.RaiseEvent(new NextTurnEvent()); });
        }

        private CharacterEntity SpawnUnit(CharacterEntity prefab, Transform parent, Owner owner, string characterName,
            Dictionary<StatKey, float> stats)
        {
            var actorData = _diContainer.InstantiatePrefab(prefab, parent).GetComponent<CharacterEntity>();
            actorData.Add(new Component_Owner(owner));
            actorData.Add(new Component_ID(characterName));
            actorData.Add(new Component_Life((int)stats[StatKey.MaxHealth]));
            actorData.Add(new Component_Attack((int)stats[StatKey.AttackPower], stats[StatKey.CriticalChance],
                stats[StatKey.CriticalRate]));
            actorData.Add(new Component_Mana((int)stats[StatKey.MaxMana]));
            actorData.Add(new Component_Defense((int)stats[StatKey.Defense], stats[StatKey.Evasion]));
            actorData.Add(new Component_Turn(Random.Range(1, 6)));
            //actorData.AddProperty(AtomicAPI.Description, "Description Lores Insum");
            //actorData.AddProperty(AtomicAPI.Icon, icon);
            return actorData;
        }
    }
}