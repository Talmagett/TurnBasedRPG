using System;
using Battle;
using Configs;
using UnityEngine;

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

        public void EnterBattle(EnemyRiftConfig enemyRiftConfig)
        {
            OnGameStateChanged?.Invoke(GameState.Battle);
            //battle.SetupEnvironment(enemyRiftConfig.Environment);
            //battle.SetupActors(_partyController.GetHeroes(), enemyRiftConfig.Enemies);
        }

        public void ExitBattle()
        {
            OnGameStateChanged?.Invoke(GameState.Map);
        }
    }
}