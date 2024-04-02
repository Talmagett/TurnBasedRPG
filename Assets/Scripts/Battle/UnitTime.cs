using System;
using Battle.Characters;

namespace Battle
{
    [Serializable]
    public class UnitTime
    {
        public BattleActor character;
        public float time;
    }
}