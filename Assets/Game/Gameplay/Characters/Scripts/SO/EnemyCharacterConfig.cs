using Game.Meta.Items.Scripts.ItemModule;
using UnityEngine;

namespace Game.Gameplay.Characters.Scripts.SO
{
    [CreateAssetMenu(fileName = "HeroConfig", menuName = "SO/HeroConfig", order = 0)]
    public class EnemyCharacterConfig : CharacterConfig
    {
        [field: SerializeField] public ItemConfig[] LootItems { get; private set; }
    }
}