using System;
using Game.Configs.Configs;
using Game.Gameplay.Battle;
using Game.Gameplay.Game.Heroes;
using Game.UI.Scripts.Views;
using UnityEngine;
using Zenject;

namespace Game.Gameplay.Game
{
    public class GameStateController : MonoBehaviour
    {
        private BattleController _battleController;
        private UIController _uiController;

        private void Awake()
        {
            OnGameStateChanged?.Invoke(GameState.Map);
        }

        private void OnEnable()
        {
            _battleController.OnStateChanged += OnBattleStateChanged;
        }

        public event Action<GameState> OnGameStateChanged;

        [Inject]
        public void Construct(BattleController battleController, HeroParty heroParty, UIController uiController)
        {
            _battleController = battleController;
            _uiController = uiController;
        }

        private void OnBattleStateChanged(BattleController.BattleState battleState)
        {
            Debug.Log(battleState);
            switch (battleState)
            {
                case BattleController.BattleState.Going:
                    break;
                case BattleController.BattleState.Exit:
                    ExitBattle();
                    break;
                case BattleController.BattleState.Win:
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
            _battleController.SetupBattle(enemyRiftConfig);
            //_uiController.Open();
        }

        public void ExitBattle()
        {
            OnGameStateChanged?.Invoke(GameState.Map);
            _battleController.ClearBattle();
            //_uiController.Close();
        }
    }
}