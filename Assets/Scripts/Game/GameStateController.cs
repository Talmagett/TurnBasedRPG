using System;
using Battle;
using Configs;
using Game.Heroes;
using UnityEngine;
using Visual.UI;
using Zenject;

namespace Game
{
    public class GameStateController : MonoBehaviour
    {
        private BattleController _battleController;
        private UIController _uiController;

        private void Awake()
        {
            OnGameStateChanged?.Invoke(GameState.Map);
        }

        public event Action<GameState> OnGameStateChanged;

        [Inject]
        public void Construct(BattleController battleController, HeroParty heroParty, UIController uiController)
        {
            _battleController = battleController;
            _uiController = uiController;
        }

        public void EnterBattle(EnemyRiftConfig enemyRiftConfig)
        {
            OnGameStateChanged?.Invoke(GameState.Battle);
            _battleController.SetupBattle(enemyRiftConfig);
            _uiController.Open();
        }

        public void ExitBattle()
        {
            OnGameStateChanged?.Invoke(GameState.Map);
            //_battleController.ClearBattle();
            _uiController.Close();
        }
    }
}