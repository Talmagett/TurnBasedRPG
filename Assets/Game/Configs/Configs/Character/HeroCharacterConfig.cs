using Character;
using Configs.Abilities;
using Modules.Items.Scripts.ItemModule;
using UnityEngine;

namespace Configs.Character
{
    [CreateAssetMenu(fileName = "HeroConfig", menuName = "SO/HeroConfig", order = 0)]
    public class HeroCharacterConfig : CharacterConfig
    {
        [field: SerializeField] public ItemConfig[] EquippedItems { get; private set; }
        [field: SerializeField] public AbilityConfig[] Abilities { get; private set; }
    }
}