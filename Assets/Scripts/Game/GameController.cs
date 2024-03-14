using Battle;
using Data;
using Map;
using Map.Characters;
using UnityEngine;
using Zenject;

namespace Game
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private MapController map;
        [SerializeField] private BattleController battle;

        private PartyController _partyController;

        public bool IsBattle { get; private set; }

        private void Awake()
        {
            map.EnterState();
            battle.ExitState();
        }

        [Inject]
        public void Construct(PartyController partyController)
        {
            _partyController = partyController;
        }

        public void EnterBattle(EnemyRiftConfig enemyRiftConfig)
        {
            IsBattle = true;
            battle.Setup(_partyController.GetHeroes(), enemyRiftConfig);
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