using System.Collections.Generic;
using Game.Configs.Configs;
using Game.Configs.Configs.Character;
using Game.Configs.Configs.Enums;
using Game.GameEngine.Entities.Scripts.Base;
using Game.Meta.Inventory.Equipment;

namespace Game.Gameplay.Game.Heroes
{
    public class Hero : ListEntity
    {
        public Hero(HeroCharacterConfig characterConfig, Dictionary<StatKey, float> stats = null)
        {
            var equipment = new Equipment();
            
            var itemConfigs = characterConfig.EquippedItems;
            Add(new SharedCharacterStats(stats ?? characterConfig.Stats.CloneStats()));
            Add(characterConfig);
            Add(equipment);
            Add(new EquipmentEffector.EquipmentEffector(this, equipment));
            foreach (var itemConfig in itemConfigs) equipment.EquipItem(itemConfig.item.Clone());
        }
    }
}