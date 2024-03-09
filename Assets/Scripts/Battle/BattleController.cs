using Data;
using Game;
using SystemCode;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Battle
{
    public class BattleController : GameStateController
    {
        [SerializeField] private Transform battleParent;

        public override void EnterState()
        {
            base.EnterState();
            PlayerInputActions.Battle.Enable();
        }
        
        public override void ExitState()
        {
            base.ExitState();
            PlayerInputActions.Battle.Disable();
            
            while (battleParent.childCount > 0)
            {
                DestroyImmediate(battleParent.GetChild(0).gameObject);
            }
        }
        
        public void Setup(EnemyRiftConfig enemyRiftConfig)
        {
            Instantiate(enemyRiftConfig.Environment, battleParent);
            foreach (var enemy in enemyRiftConfig.Enemies)
            {
                Instantiate(enemy, battleParent.position+Random.insideUnitSphere*5,Quaternion.identity,battleParent);
            }
        }
    }
}