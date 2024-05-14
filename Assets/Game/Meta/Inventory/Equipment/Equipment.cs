using System;
using System.Collections.Generic;
using System.Linq;
using Game.Meta.Items.Scripts.ItemModule;
using UnityEngine;

namespace Game.Meta.Inventory.Equipment
{
    [Serializable]
    public sealed class Equipment
    {
        private readonly Dictionary<EquipmentType, Item> _equipment = new();

        public event Action<Item> OnItemEquipped;
        public event Action<Item> OnItemUnequipped;

        private Item GetItem(EquipmentType type)
        {
            return !_equipment.ContainsKey(type) ? null : _equipment[type];
        }

        public bool TryGetItem(EquipmentType type, out Item result)
        {
            var hasItem = HasItem(type);
            result = GetItem(type);
            return hasItem;
        }

        private bool HasItem(EquipmentType type)
        {
            return _equipment.ContainsKey(type);
        }

        public KeyValuePair<EquipmentType, Item>[] GetItems()
        {
            return _equipment.Select(item => new KeyValuePair<EquipmentType, Item>(item.Key, item.Value)).ToArray();
        }

        public void EquipItem(Item item)
        {
            var type = item.GetComponent<Component_EquipmentType>().Type;

            if (HasItem(type)) UnequipItem(type);

            _equipment.Add(type, item);
            Debug.Log(item.Name);
            OnItemEquipped?.Invoke(item);
        }

        public void UnequipItem(Item item)
        {
            var type = item.GetComponent<Component_EquipmentType>().Type;

            if (!_equipment.ContainsKey(type)) return;

            _equipment.Remove(type);
            Debug.Log(item.Name);
            OnItemUnequipped?.Invoke(item);
        }

        public void UnequipItem(EquipmentType equipmentType)
        {
            _equipment.Remove(equipmentType);
            OnItemUnequipped?.Invoke(_equipment[equipmentType]);
        }
    }
}