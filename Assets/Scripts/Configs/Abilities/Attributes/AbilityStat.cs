using System;
using Configs.Enums;

namespace Configs.Abilities.Attributes
{
    [Serializable]
    public struct AbilityStat
    {
        public StatKey Stat;
        public float BaseValue;
        public float MultValue;
    }
}