using System;
using Battle.Core;
using Battle.Player;
using UnityEngine;

namespace Battle.Abilities
{
    [Serializable]
    public abstract class Ability : MonoBehaviour
    {
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public int Usage { get; private set; }
        protected BattleUnit BattleUnit;
        protected PlayerController PlayerController;

        public void Init(BattleUnit battleUnit, PlayerController playerController)
        {
            BattleUnit = battleUnit;
            PlayerController = playerController;
        }

        public abstract void StartAbility();
    }
}