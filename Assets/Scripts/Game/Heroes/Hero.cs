using System.Collections.Generic;
using Battle.Actors;
using Configs;
using Configs.Character;
using Configs.Enums;

namespace Game.Heroes
{
    public class Hero
    {
        public readonly string Name;
        public readonly CharacterConfig CharacterConfig;
        public readonly ActorData Prefab;
        public readonly SharedCharacterStats Stats;

        public Hero(CharacterConfig characterConfig, Dictionary<StatKey, float> stats = null)
        {
            Name = characterConfig.Name;
            CharacterConfig = characterConfig;
            Prefab = characterConfig.Prefab;
            Stats = new SharedCharacterStats(stats ?? characterConfig.Stats.CloneStats());
        }
    }
}