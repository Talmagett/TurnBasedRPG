using System;
using Game.Gameplay.Characters.Scripts.Keys;

namespace Game.Gameplay.Abilities.Scripts
{
    [Serializable]
    public struct AbilityStat
    {
        public StatKey Stat;
        public float BaseValue;
        public float MultValue;
    }
}