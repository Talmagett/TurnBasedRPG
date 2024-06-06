using System.Collections;
using System.Collections.Generic;
using Game.Gameplay.Abilities.Scripts;
using Game.Gameplay.Characters.Scripts.Components;
using Game.Meta.Items.Scripts.ItemModule;
using UnityEngine;

namespace Game.Gameplay.Characters.Scripts.SO
{
    [CreateAssetMenu(fileName = "HeroConfig", menuName = "SO/HeroConfig", order = 0)]
    public class HeroCharacterConfig : CharacterConfig
    {
        [field: SerializeField] public ItemConfig[] EquippedItems { get; private set; }
        [field: SerializeField] public HeroAbilityPack AbilitiesPack { get; private set; }
    }
}