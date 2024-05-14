using System;
using Game.Configs.Configs.Enums;

namespace Game.Configs.Configs.Attributes
{
    [Serializable]
    public class StatMultiplicative
    {
        public StatKey Stat;
        public float Value;
    }
}