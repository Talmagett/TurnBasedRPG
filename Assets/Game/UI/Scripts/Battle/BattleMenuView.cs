using Game.Gameplay.Battle;
using Game.UI.Scripts.Views;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Game.UI.Scripts.Battle
{
    public class BattleMenuView : MonoBehaviour
    {
        [SerializeField] private Button exitBattle;

        private BattleController _battleController;
        private UIController _uiController;

        private void OnEnable()
        {
            exitBattle.onClick.AddListener(ExitBattle);
        }

        private void OnDisable()
        {
            exitBattle.onClick.RemoveListener(ExitBattle);
        }

        [Inject]
        public void Construct(BattleController battleController, UIController uiController)
        {
            _battleController = battleController;
            _uiController = uiController;
        }

        private void ExitBattle()
        {
            //_uiController.Open();
            _battleController.ExitBattle();
        }
    }
}