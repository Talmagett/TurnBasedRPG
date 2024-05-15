using System;
using Game.Gameplay.Characters.Scripts.Keys;

namespace Game.Gameplay.Abilities.Scripts
{
    [Serializable]
    public class StatAdditive
    {
        public StatKey Stat;
        public float Value;
    }
}