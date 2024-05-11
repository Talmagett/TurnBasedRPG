using System.Collections.Generic;
using Character;
using Configs;
using Configs.Character;
using Configs.Enums;
using Entities;
using Modules.Items.Scripts.Equipment;

namespace Game.Heroes
{
    public class Hero : ListEntity
    {
        public readonly CharacterConfig CharacterConfig;
        public readonly Equipment Equipment;
        public readonly string Name;
        public readonly CharacterEntity Prefab;
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