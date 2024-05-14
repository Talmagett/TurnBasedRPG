using System;
using Game.Configs.Configs.Enums;
using UnityEngine;

namespace Game.Configs.Configs.Character
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