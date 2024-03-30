using System;
using Actors;
using Battle;
using Data;
using Map;
using Map.Characters;
using UnityEngine;
using Zenject;

namespace Game
{
    public class GameStateController : MonoBehaviour
    {
        public event Action<GameState> OnGameStateChanged;
        
        private BattleController _battleController;
        
        private void Awake()
        {
            OnGameStateChanged?.Invoke(GameState.Map);
        }

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