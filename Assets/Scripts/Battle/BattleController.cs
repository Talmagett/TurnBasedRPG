using System;
using Data;
using Game;
using Map.Characters;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Battle
{
    public class BattleController : GameStateController
    {
        public event Action OnNextTurn;
        
        [SerializeField] private Transform environmentParent;
        
        [field:SerializeField] public Side PlayerSide { get; private set; }
        [field:SerializeField] public Side EnemiesSide { get; private set; }

        public BattleQueue BattleQueue { get; private set; }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                NextTurn();
            }
        }

        public void NextTurn()
        {
            BattleQueue.NextTurn();
            OnNextTurn?.Invoke();
        }

        public override void EnterState()
        {
            base.EnterState();
            PlayerInputActions.Battle.Enable();
            NextTurn();
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
        
        public void Setup(PlayerCharacter[] playerCharacters, EnemyRiftConfig enemyRiftConfig)
        {
            BattleQueue = new BattleQueue();
            
            Instantiate(enemyRiftConfig.Environment, environmentParent);
            SpawnUnit(true,playerCharacters);
            SpawnUnit(false,enemyRiftConfig.Enemies);
        }

        public void SpawnUnit(bool isPlayer, params BaseCharacter[] characters)
        {
            if (isPlayer)
            {
                PlayerSide.SpawnUnits(characters);
                BattleQueue.AddUnits(PlayerSide.GetAllCharacters());
            }
            else
            {
                EnemiesSide.SpawnUnits(characters);
                BattleQueue.AddUnits(EnemiesSide.GetAllCharacters());
            }
        }
    }
}