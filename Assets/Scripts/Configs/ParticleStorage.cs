using System;
using Battle.Characters;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(menuName = "SO/Create ParticleStorage", fileName = "ParticleStorage", order = 0)]
    public class ParticleStorage : ScriptableObject
    {
        [field: SerializeField] public ParticleSystem HealEffect {get; private set;}
        [field: SerializeField] public ParticleSystem Hit1Effect {get; private set;}

        public ParticleSystem GetParticle(ParticleKeys key)
        {
            return key switch
            {
                ParticleKeys.Hit1 => Hit1Effect,
                ParticleKeys.Hit2 => Hit1Effect,
                ParticleKeys.Heal => HealEffect,
                _ => null
            };
        }
        public enum ParticleKeys
        {
            Hit1,
            Hit2,
            Heal
        }
    }
}