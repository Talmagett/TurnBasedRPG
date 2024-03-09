using System;
using Battle;
using Data;
using Map;
using UnityEngine;
using Zenject;
using Environment = Battle.Environment;
using Random = UnityEngine.Random;

namespace Game
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private MapController map;
        [SerializeField] private BattleController battle;
        
        public bool IsBattle { get; private set; }

        private void Awake()
        {
            map.EnterState();
            battle.ExitState();
        }
        
        public void EnterBattle(EnemyRiftConfig enemyRiftConfig)
        {
            IsBattle = true;
            battle.Setup(enemyRiftConfig);
            ChangeState();
        }
        
        public void ExitBattle()
        {
            IsBattle = false;
            ChangeState();
        }

        private void ChangeState()
        {
            if (IsBattle)
            {
                map.ExitState();
                battle.EnterState();
            }
            else
            {
                map.EnterState();
                battle.ExitState();
            }
        }
    }
}