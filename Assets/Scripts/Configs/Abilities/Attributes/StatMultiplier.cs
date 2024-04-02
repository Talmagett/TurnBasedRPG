using System;
using Configs.Enums;

namespace Configs.Abilities.Attributes
{
    [Serializable]
    public class StatMultiplier : IAttribute
    {
        public StatKey Stat;
        public float Multiplier;
    }
}