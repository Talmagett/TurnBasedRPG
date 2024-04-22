using System;
using UnityEngine;

namespace Game.Scripts.Configs.Abilities
{
    [Serializable]
    public class ChangeTurnPointCommand : IAbilityCommand
    {
        [SerializeField] private int addingTurnPoints;

        public void Execute(AbilityEvent abilityEvent, Action action)
        {
        }
    }
}