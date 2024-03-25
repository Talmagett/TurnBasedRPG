using Actors;
using Battle;
using Data;
using Map;
using UnityEngine;

namespace Game
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private MapController map;
        [SerializeField] private BattleController battle;
        [SerializeField] private BattleActor[] heroes;
        
        public bool IsBattle { get; private set; }

        private void Awake()
        {
            map.EnterState();
            battle.ExitState();
        }

        public void EnterBattle(EnemyRiftConfig enemyRiftConfig)
        {
            IsBattle = true;
            battle.Setup(heroes, enemyRiftConfig.Enemies,enemyRiftConfig.Environment);
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