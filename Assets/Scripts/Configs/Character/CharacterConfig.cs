using Battle.Actors;
using UnityEngine;

namespace Configs.Character
{
    [CreateAssetMenu(fileName = "CharacterConfig", menuName = "SO/CharacterConfig", order = 0)]
    public class CharacterConfig : ScriptableObject
    {
        [field: SerializeField] public string Name { get; private set; }
        [field: SerializeField] public string Description { get; private set; }
        [field: SerializeField] public Sprite Icon { get; private set; }

        [field: SerializeField] [field: Space] public ActorData Prefab { get; private set; }
        [field: SerializeField] public BaseCharacterStatsConfig Stats { get; private set; }
    }
}