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
        
        public override IList<object> Clone()
        {
            return new List<object>()
            {
                Description,
                Icon,
                Prefab,
                new Component_ID(ComponentID.id.Value),
                new Component_Life(ComponentLife.maxHealth.Value),
                new Component_Mana(ComponentMana.maxMana.Value),
                new Component_Attack((int)ComponentAttack.attackPower.Value,ComponentAttack.criticalChance.Value,ComponentAttack.criticalRate.Value),
                new Component_Defense((int)ComponentDefense.defense.Value,ComponentDefense.evasion.Value),
                new Component_Owner(ComponentOwner.owner.Value),
                new Component_Turn(Random.Range(1, 6)),
                AbilitiesPack.Clone()
            };
        }
    }
}