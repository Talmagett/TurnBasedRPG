using Data;
using Game;
using Map.Characters;
using UnityEngine;
using Zenject;

namespace Battle
{
    public class BattleController : GameStateController
    {
        [SerializeField] private Transform environmentParent;
        
        [field:SerializeField] public Side PlayerSide { get; private set; }
        [field:SerializeField] public Side EnemiesSide { get; private set; }

        private PartyController _partyController;
        
        [Inject]
        public void Construct(PartyController partyController)
        {
            _partyController = partyController;
        }

        public override void EnterState()
        {
            base.EnterState();
            PlayerInputActions.Battle.Enable();
        }
        
        public override void ExitState()
        {
            base.ExitState();
            PlayerInputActions.Battle.Disable();
            while (environmentParent.childCount>0)
            {
                DestroyImmediate(environmentParent.GetChild(0).gameObject);
            }
            PlayerSide.ClearField();
            EnemiesSide.ClearField();
        }
        
        public void Setup(EnemyRiftConfig enemyRiftConfig)
        {
            Instantiate(enemyRiftConfig.Environment, environmentParent);
            
            PlayerSide.SpawnUnits(_partyController.GetHeroes());
            EnemiesSide.SpawnUnits(enemyRiftConfig.Enemies);
        }
    }
}