using System;
using Battle;
using Data;
using Map;
using Map.Characters;
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
        
        private PartyController _partyController;
        
        [Inject]
        public void Construct(PartyController partyController)
        {
            _partyController = partyController;
        }

        private void Awake()
        {
            map.EnterState();
            battle.ExitState();
        }

        public void EnterBattle(EnemyRiftConfig enemyRiftConfig)
        {
            IsBattle = true;
            battle.Setup(_partyController.GetHeroes(),enemyRiftConfig);
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