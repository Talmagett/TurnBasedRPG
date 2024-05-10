using System;
using Configs.Enums;
using UnityEngine;

namespace Battle.Actors.Model
{
    [Serializable]
    public class Stats
    {
        [field: SerializeField] public StatKey Name { get; private set; }
        [field: SerializeField] public float Value { get; private set; }

        public Stats(StatKey name, float value)
        {
            Name = name;
            Value = value;
        }
    }
}