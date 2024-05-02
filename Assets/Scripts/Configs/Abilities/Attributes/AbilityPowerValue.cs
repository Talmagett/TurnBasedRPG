using System;
using Configs.Enums;

namespace Configs.Abilities.Attributes
{
    [Serializable]
    public class AbilityPowerValue
    {
        public float BonusValue;
        public StatKey Stat;
        public float StatMultiplier;
    }
}