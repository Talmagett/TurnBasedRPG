using System;
using Game.Configs.Configs.Enums;

namespace Game.Configs.Configs.Attributes
{
    [Serializable]
    public struct AbilityStat
    {
        public StatKey Stat;
        public float BaseValue;
        public float MultValue;
    }
}