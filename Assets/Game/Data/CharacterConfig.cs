using UnityEngine;

namespace Game.Data
{
    [CreateAssetMenu(fileName = "CharacterConfig", menuName = "SO/CharacterConfig", order = 0)]
    public class CharacterConfig : ScriptableObject
    {
        [field: SerializeField] public int Health { get; private set; }
    }
}