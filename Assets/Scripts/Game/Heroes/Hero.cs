using System.Collections.Generic;
using Configs;
using Configs.Character;
using Configs.Enums;
using Modules.Entities.Scripts.Base;
using Modules.Items.Scripts.Equipment;

namespace Game.Heroes
{
    public class Hero : ListEntity
    {
        public Hero(HeroCharacterConfig characterConfig, Dictionary<StatKey, float> stats = null)
        {

            var equipment = new Equipment();
            Add(new SharedCharacterStats(stats ?? characterConfig.Stats.CloneStats()));
            Add(characterConfig);
            Add(equipment);

            var equipmentEffector = new EquipmentEffector.EquipmentEffector(this, equipment);
            var itemConfigs = characterConfig.EquippedItems;
            foreach (var itemConfig in itemConfigs) equipment.EquipItem(itemConfig.item.Clone());
        }
    }
}