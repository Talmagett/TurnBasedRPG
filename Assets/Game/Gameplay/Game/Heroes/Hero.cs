using Game.GameEngine.Entities.Scripts.Base;
using Game.Gameplay.Characters.Scripts.SO;
using Game.Meta.Inventory.Equipment;

namespace Game.Gameplay.Game.Heroes
{
    public class Hero : ListEntity
    {
        public Hero(HeroCharacterConfig characterConfig)
        {
            var equipment = new Equipment();
            
            var itemConfigs = characterConfig.EquippedItems;
            AddRange(characterConfig.CloneComponents());
            Add(characterConfig);
            Add(equipment);
            Add(new EquipmentEffector.EquipmentEffector(this, equipment));
            foreach (var itemConfig in itemConfigs) equipment.EquipItem(itemConfig.item.Clone());
        }
    }
}