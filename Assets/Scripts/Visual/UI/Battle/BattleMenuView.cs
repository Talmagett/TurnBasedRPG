using Game;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Visual.UI.Battle
{
    public class BattleMenuView : MonoBehaviour
    {
        [SerializeField] private Button exitBattle;

        private GameStateController _gameStateController;

        [Inject]
        public void Construct(GameStateController gameStateController)
        {
            _gameStateController = gameStateController;
        }
        
        private void OnEnable()
        {
            exitBattle.onClick.AddListener(ExitBattle);
        }

        private void OnDisable()
        {
            exitBattle.onClick.RemoveListener(ExitBattle);
        }

        private void ExitBattle()
        {
            _gameStateController.ExitBattle();
        }
    }
}