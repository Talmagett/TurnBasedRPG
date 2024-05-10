using System;
using System.Collections.Generic;
using System.Linq;

namespace Modules.Items.Scripts.Equipment
{
    [Serializable]
    public sealed class Equipment
    {
        /*private readonly Dictionary<EquipmentType, Item.Item> _equipment = new();

        public event Action<Item.Item> OnItemEquipped;
        public event Action<Item.Item> OnItemUnequipped;

        public void Setup(params KeyValuePair<EquipmentType, Item.Item>[] items)
        {
            foreach (var itemPair in items) EquipItem(itemPair.Key, itemPair.Value);
        }

        private Item.Item GetItem(EquipmentType type)
        {
            return !_equipment.ContainsKey(type) ? null : _equipment[type];
        }

        public bool TryGetItem(EquipmentType type, out Item.Item result)
        {
            var hasItem = HasItem(type);
            result = GetItem(type);
            return hasItem;
        }

        public void UnequipItem(EquipmentType type, Item.Item item)
        {
            if (!_equipment.ContainsKey(type)) return;

            _equipment.Remove(type);
            OnItemUnequipped?.Invoke(item);
        }

        public void EquipItem(EquipmentType type, Item.Item item)
        {
            if (HasItem(type)) UnequipItem(type, _equipment[type]);

            _equipment.Add(type, item);
            OnItemEquipped?.Invoke(item);
        }

        public bool HasItem(EquipmentType type)
        {
            return _equipment.ContainsKey(type);
        }

        public KeyValuePair<EquipmentType, Item.Item>[] GetItems()
        {
            return _equipment.Select(item => new KeyValuePair<EquipmentType, Item.Item>(item.Key, item.Value)).ToArray();
        }

        public void EquipItem(Item.Item item)
        {
            var equipmentType = item.GetComponent<EquipmentTypeComponent>();
            EquipItem(equipmentType.Type, item);
        }

        public void UnequipItem(Item.Item item)
        {
            var equipmentType = item.GetComponent<EquipmentTypeComponent>();
            UnequipItem(equipmentType.Type, item);
        }*/
    }
}