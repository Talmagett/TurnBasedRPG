using System;
using UnityEngine;
using Zenject;

namespace Game
{
    [Serializable]
    public class GameStateListener : MonoBehaviour
    {
        [SerializeField] private StateElements mapState;
        [SerializeField] private StateElements battleState;
        private GameStateController _gameStateController;


        private PlayerInputActions _playerInputActions;

        private void OnDestroy()
        {
            _gameStateController.OnGameStateChanged -= ChangeState;
        }

        [Inject]
        public void Construct(GameStateController gameStateController, PlayerInputActions playerInputActions)
        {
            _gameStateController = gameStateController;
            _playerInputActions = playerInputActions;
            _gameStateController.OnGameStateChanged += ChangeState;
        }

        private void ChangeState(GameState state)
        {
            if (state == GameState.Map)
            {
                battleState.ExitState();
                mapState.EnterState();
                _playerInputActions.Map.Enable();
                _playerInputActions.Battle.Disable();
            }
            else
            {
                battleState.EnterState();
                mapState.ExitState();
                _playerInputActions.Battle.Enable();
                _playerInputActions.Map.Disable();
            }
        }

        [Serializable]
        public class StateElements
        {
            [SerializeField] private Camera stateCamera;
            [SerializeField] private GameObject canvas;
            
            public void EnterState()
            {
                canvas.SetActive(true);
                stateCamera.gameObject.SetActive(true);
            }

            public void ExitState()
            {
                canvas.SetActive(false);
                stateCamera.gameObject.SetActive(false);
            }
        }
    }
}