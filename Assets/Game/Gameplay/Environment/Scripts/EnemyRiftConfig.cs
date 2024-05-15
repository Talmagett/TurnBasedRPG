using Game.Gameplay.Characters.Scripts.SO;
using Game.Meta.Items.Scripts.ItemModule;
using UnityEngine;

namespace Game.Gameplay.Environment.Scripts
{
    [CreateAssetMenu(fileName = "EnemyRift", menuName = "SO/EnemyRift", order = 1)]
    public class EnemyRiftConfig : ScriptableObject
    {
        [field: SerializeField] public string ID { get; private set; }
        [field: SerializeField] public Battle.Environment Environment { get; private set; }
        [field: SerializeField] public EnemyCharacterConfig[] Enemies { get; private set; }
        [field: SerializeField] public ItemConfig[] LootItems { get; private set; }
    }
}