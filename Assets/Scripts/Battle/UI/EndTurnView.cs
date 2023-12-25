using System;
using Battle.Core;
using UnityEngine;
using UnityEngine.UI;

namespace Battle.UI
{
    public class EndTurnView:MonoBehaviour
    {
        [SerializeField] private Button button;

        private void OnEnable()
        {
            BattleUnit.OnSelected += EndTurn;
        }

        private void OnDisable()
        {
            BattleUnit.OnSelected -= EndTurn;
        }

        private void EndTurn(BattleUnit selectedUnit)
        {
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(selectedUnit.EndTurn);
        }
    }
}