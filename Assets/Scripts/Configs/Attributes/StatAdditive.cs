using System;
using Configs.Enums;

namespace Configs.Attributes
{
    [Serializable]
    public class StatAdditive
    {
        public StatKey Stat;
        public float Value;
    }
}