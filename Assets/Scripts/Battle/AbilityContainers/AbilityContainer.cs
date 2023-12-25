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

        public abstract Ability CreateAbility(BattleUnit owner, IAbilityCaster casterType);
    }
}