using Actors;
using UnityEngine;

namespace Data
{
    [CreateAssetMenu(fileName = "CharacterConfig", menuName = "SO/CharacterConfig", order = 0)]
    public class CharacterConfig : ScriptableObject
    {
        [field: SerializeField] public string ID { get; private set; }
        [field: SerializeField] public Sprite Icon { get; private set; }
        
        [field: SerializeField, Space] public ActorData Prefab { get; private set; }
        [field: SerializeField] public CharacterStatistic Stats { get; private set; }
    }
}