using System;
using Configs;
using UnityEngine;

namespace Battle.Characters
{
    [Serializable]
    [CreateAssetMenu(fileName = "New Ability", menuName = "SO/Ability/DealDamage", order = 0)]
    public class DealDamageAbility : Ability
    {
        [field: SerializeField] public ParticleSystem Particle { get; private set; }
        [field: SerializeField] public int BonusDamage { get; private set; }
        [field: SerializeField] public float AttackPowerMultiplier { get; private set; }
    }
}