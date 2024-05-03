using System;
using Configs.Enums;

namespace Configs.Abilities.Attributes
{
    [Serializable]
    public class StatMultiplicative
    {
        public StatKey Stat;
        public float Value;
    }
}