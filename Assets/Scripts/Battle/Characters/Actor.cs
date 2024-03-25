using Data;
using Sirenix.OdinInspector;

namespace Battle.Characters
{
    [System.Serializable]
    public class Actor
    {
        [ReadOnly]
        public SharedCharacterStatistics stats;

        private readonly CharacterConfig _characterConfig;

        public Actor(CharacterConfig characterConfig)
        {
            _characterConfig = characterConfig;
            stats = new SharedCharacterStatistics();
            stats.Init(_characterConfig.Stats);
        }
    }
}