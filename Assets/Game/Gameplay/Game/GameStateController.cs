using System;
using Cysharp.Threading.Tasks;
using Game.Gameplay.Battle;
using Game.Gameplay.Environment.Scripts;
using Game.Gameplay.Game.Heroes;
using Game.Meta.Inventory.Inventory;
using Game.UI.Scripts.Views;
using UnityEngine;
using Zenject;

namespace Game.Gameplay.Game
{
    public class GameStateController : MonoBehaviour
    {
        private BattleController _battleController;
        private EnemyRiftConfig _enemyRiftConfig;
        private Inventory _inventory;
        
        public event Action<GameState> OnGameStateChanged;

        [Inject]
        public void Construct(BattleController battleController, Inventory inventory)
        {
            _battleController = battleController;
            _inventory = inventory;
        }
        
        private void Awake()
        {
            OnGameStateChanged?.Invoke(GameState.Map);
        }

        private void OnEnable()
        {
            _battleController.OnStateChanged += OnBattleStateChanged;
        }

        private void OnBattleStateChanged(BattleController.BattleState battleState)
        {
            switch (battleState)
            {
                case BattleController.BattleState.Going:
                    break;
                case BattleController.BattleState.Exit:
                    break;
                case BattleController.BattleState.Win:
                    GivePlayerLoot();
                    ExitBattle();
                    break;
                case BattleController.BattleState.Lose:
                    ExitBattle();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(battleState), battleState, null);
            }
        }

        public void EnterBattle(EnemyRiftConfig enemyRiftConfig)
        {
            OnGameStateChanged?.Invoke(GameState.Battle);
            _enemyRiftConfig = enemyRiftConfig;

            _battleController.SetupBattle(enemyRiftConfig);
        }
        
        public void ExitBattle()
        {
            OnGameStateChanged?.Invoke(GameState.Map);
            _battleController.ClearBattle().Forget();
        }
        
        private void GivePlayerLoot()
        {
            foreach (var itemConfig in _enemyRiftConfig.LootItems)
            {
                _inventory.AddItem(itemConfig.item);
            }
        }
    }
}