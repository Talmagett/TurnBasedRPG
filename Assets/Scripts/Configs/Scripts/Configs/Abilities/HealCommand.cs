using System;
using UnityEngine;

namespace Game.Scripts.Configs.Abilities
{
    [Serializable]
    public class HealCommand : IAbilityCommand
    {
        [SerializeField] private int baseDamage;
        [SerializeField] private float attackPowerMultiplier;

        public void Execute(AbilityEvent abilityEvent, Action action)
        {
            //abilityEvent.Target
        }
    }
}