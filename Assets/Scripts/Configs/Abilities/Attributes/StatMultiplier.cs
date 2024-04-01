using Configs.Enums;

namespace Configs.Abilities.Attributes
{
    [System.Serializable]
    public class StatMultiplier : IAttribute
    {
        public StatKey Stat;
        public float Multiplier;
    }
}