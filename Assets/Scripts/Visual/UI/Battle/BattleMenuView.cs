using Battle;
using Game;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Visual.UI.Battle
{
    public class BattleMenuView : MonoBehaviour
    {
        [SerializeField] private Button exitBattle;

        private BattleController _battleController;
        private UIController _uiController;
        
        [Inject]
        public void Construct(BattleController battleController,UIController uiController)
        {
            _battleController = battleController;
            _uiController = uiController;
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
            _uiController.Open();
            _battleController.ExitBattle();
        }
    }
}