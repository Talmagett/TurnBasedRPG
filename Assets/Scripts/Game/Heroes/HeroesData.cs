using System.Collections.Generic;
using Battle.Actors;
using Configs;
using Entities;
using UnityEngine;

namespace Game.Heroes
{
    public class HeroesData : ListEntity
    {
        public readonly string ID;
        public readonly Sprite Icon;
        public readonly ActorData Prefab;
        public readonly SharedCharacterStats Stats;
        
        public HeroesData(CharacterConfig characterConfig, Dictionary<StatKey,float> stats=null)
        {
            ID = characterConfig.ID;
            Icon = characterConfig.Icon;
            Prefab = characterConfig.Prefab;
            Stats = new SharedCharacterStats(stats??characterConfig.Stats.CloneStats());
        }
    }
}