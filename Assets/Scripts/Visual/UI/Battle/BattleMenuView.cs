using Game;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Visual.UI.Battle
{
    public class BattleMenuView : MonoBehaviour
    {
        [SerializeField] private Button exitBattle;

        private GameController _gameController;

        private void OnEnable()
        {
            exitBattle.onClick.AddListener(ExitBattle);
        }

        private void OnDisable()
        {
            exitBattle.onClick.RemoveListener(ExitBattle);
        }

        [Inject]
        public void Construct(GameController gameController)
        {
            _gameController = gameController;
        }

        private void ExitBattle()
        {
            _gameController.ExitBattle();
        }
    }
}