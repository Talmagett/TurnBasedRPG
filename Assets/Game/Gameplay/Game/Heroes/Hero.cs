using System.Collections.Generic;
using System.Linq;
using Game.GameEngine.Entities.Scripts.Base;
using Game.Gameplay.Abilities.Scripts;
using Game.Gameplay.Characters.Scripts;
using Game.Gameplay.Characters.Scripts.Components;
using Game.Gameplay.Characters.Scripts.SO;
using Game.Meta.Inventory.Equipment;
using Sirenix.Utilities;
using UnityEngine;

namespace Game.Gameplay.Game.Heroes
{
    public class Hero : ListEntity
    {
        public Hero(HeroCharacterConfig characterConfig)
        {
            var equipment = new Equipment();
            characterConfig.EquippedItems.Select(t=>t.item.Clone()).ForEach(u=>equipment.EquipItem(u));
            AddRange(characterConfig.Clone());
            Add(equipment);
            Add(new EquipmentEffector.EquipmentEffector(this, equipment));
        }

        public IEnumerable<object> GetComponents()
        {
            yield return Get<Component_ID>();
            yield return Get<Component_Effects>();
            yield return Get<Component_Data>();
            yield return Get<CharacterEntity>();
            yield return Get<Component_Life>();
            yield return Get<Component_Mana>();
            yield return Get<Component_Attack>();
            yield return Get<Component_Defense>();
            yield return Get<Component_Owner>();
            yield return Get<Component_Turn>();
            yield return Get<HeroAbilityPack>();
        }
    }
}