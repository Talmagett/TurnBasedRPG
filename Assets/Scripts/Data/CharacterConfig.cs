using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "CharacterConfig", menuName = "SO/CharacterConfig", order = 0)]
    public class CharacterConfig : ScriptableObject
    {
        public string Name;
        public Sprite Icon;
        public CharacterStatistic Stats;
    }
}