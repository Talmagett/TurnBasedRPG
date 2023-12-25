using System;
using Battle.Core;
using Battle.Player;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Battle.AI
{
    public abstract class AI:MonoBehaviour, IAbilityCaster
    {
        protected BattleUnit BattleUnit;

        private void Awake()
        {
            BattleUnit = GetComponent<BattleUnit>();
        }

        private void OnEnable()
        {
            BattleUnit.OnSelected += StartTurn;
        }

        private void OnDisable()
        {
            BattleUnit.OnSelected -= StartTurn;
        }

        protected abstract void StartTurn(BattleUnit selected);
        public abstract UniTask<TargetResult> GetTarget();
    }
}