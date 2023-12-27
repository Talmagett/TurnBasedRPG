using System;
using Battle.Abilities;
using Battle.Core;
using Battle.Player;
using UnityEngine;

namespace Battle.AbilityContainers
{
    [Serializable]
    public abstract class AbilityContainer : MonoBehaviour
    {
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public int Usage { get; private set; }
        [field: SerializeField] public int MaxLevel { get; private set; } = 1;
        [field: SerializeField] public int CurrentLevel { get; private set; } = 1;
        public abstract Ability CreateAbility(BattleUnit owner, IAbilityCaster casterType);
    }
}