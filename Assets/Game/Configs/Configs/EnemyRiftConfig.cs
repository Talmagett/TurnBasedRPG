using Battle;
using Configs.Character;
using Modules.Items.Scripts.ItemModule;
using UnityEngine;

namespace Configs
{
    [CreateAssetMenu(fileName = "EnemyRift", menuName = "SO/EnemyRift", order = 1)]
    public class EnemyRiftConfig : ScriptableObject
    {
        [field: SerializeField] public string ID { get; private set; }
        [field: SerializeField] public Environment Environment { get; private set; }
        [field: SerializeField] public EnemyCharacterConfig[] Enemies { get; private set; }
        [field: SerializeField] public ItemConfig[] LootItems { get; private set; }
    }
}