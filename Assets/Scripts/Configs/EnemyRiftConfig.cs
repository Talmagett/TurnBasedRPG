using Battle;
using Configs.Character;
using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "EnemyRift", menuName = "SO/EnemyRift", order = 1)]
    public class EnemyRiftConfig : ScriptableObject
    {
        [field: SerializeField] public string ID { get; private set; }
        [field: SerializeField] public Environment Environment { get; private set; }

        [field: SerializeField] public CharacterConfig[] Enemies { get; private set; }
        //loot
    }
}