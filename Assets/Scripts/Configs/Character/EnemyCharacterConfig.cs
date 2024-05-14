using Character;
using Configs.Abilities;
using Modules.Items.Scripts.ItemModule;
using UnityEngine;

namespace Configs.Character
{
    [CreateAssetMenu(fileName = "HeroConfig", menuName = "SO/HeroConfig", order = 0)]
    public class EnemyCharacterConfig : CharacterConfig
    {
        [field: SerializeField] public ItemConfig[] LootItems { get; private set; }
    }
}