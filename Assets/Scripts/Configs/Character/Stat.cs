using System;
using Configs.Enums;
using UnityEngine;

namespace Configs.Character
{
    [Serializable]
    public class Stat
    {
        [field: SerializeField] public StatKey Name { get; private set; }
        [field: SerializeField] public float Value { get; private set; }

        public Stat(StatKey name, float value)
        {
            Name = name;
            Value = value;
        }
    }
}