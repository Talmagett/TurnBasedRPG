using System;
using Battle.Actors;
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