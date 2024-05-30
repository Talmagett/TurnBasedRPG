using System;
using Game.Gameplay.Characters.Scripts.Keys;
using Sirenix.OdinInspector;
namespace Game.Gameplay.Abilities.Scripts
{
    [Serializable]
    public class StatAdditive
    {
        public StatKey Stat;
        public float Value;
    }
}