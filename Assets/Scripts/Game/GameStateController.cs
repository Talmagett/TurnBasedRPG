using System;
using Battle;
using Configs;
using Game.Heroes;
using UnityEngine;
using Zenject;

namespace Game
{
    public class GameStateController : MonoBehaviour
    {
        private BattleController _battleController;

        private void Awake()
        {
            OnGameStateChanged?.Invoke(GameState.Map);
        }

        public event Action<GameState> OnGameStateChanged;

        [Inject]
        public void Construct(BattleController battleController, HeroParty heroParty)
        {
            _battleController = battleController;
        }

        public void EnterBattle(EnemyRiftConfig enemyRiftConfig)
        {
            OnGameStateChanged?.Invoke(GameState.Battle);
            _battleController.Setup(enemyRiftConfig);
        }

        public void ExitBattle()
        {
            OnGameStateChanged?.Invoke(GameState.Map);
            _battleController.Clear();
        }
    }
}