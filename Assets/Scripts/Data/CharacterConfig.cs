using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "CharacterConfig", menuName = "SO/CharacterConfig", order = 0)]
    public class CharacterConfig : ScriptableObject
    {
        public string id;
        public Sprite icon;
        public CharacterStatistic stats;
    }
}