using System;
using Configs.Enums;

namespace Configs.Attributes
{
    [Serializable]
    public struct AbilityStat
    {
        public StatKey Stat;
        public float BaseValue;
        public float MultValue;
    }
}