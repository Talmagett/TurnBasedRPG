using Actors;
using Data;
using UnityEngine;

namespace Battle.Characters
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "New Ability", menuName = "SO/Ability/HealAbility", order = 0)]
    public class HealAbility : Ability
    {
        [field: SerializeField] public ParticleStorage.ParticleKeys ParticleKey {get; private set;}
        [field: SerializeField] public float MaxHealthPercent { get; private set; }
        [field: SerializeField] public int BonusHealth { get; private set; }
    }
}