using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Modules.Items.Scripts.Equipment
{
    [Serializable]
    public sealed class Equipment
    {
        private readonly Dictionary<EquipmentType, ItemModule.Item> _equipment = new();

        public event Action<ItemModule.Item> OnItemEquipped;
        public event Action<ItemModule.Item> OnItemUnequipped;
        //
        // public void Setup(params KeyValuePair<EquipmentType, ItemModule.Item>[] items)
        // {
        //     foreach (var itemPair in items) EquipItem(itemPair.Key, itemPair.Value);
        // }

        private ItemModule.Item GetItem(EquipmentType type)
        {
            return !_equipment.ContainsKey(type) ? null : _equipment[type];
        }

        public bool TryGetItem(EquipmentType type, out ItemModule.Item result)
        {
            var hasItem = HasItem(type);
            result = GetItem(type);
            return hasItem;
        }

        private bool HasItem(EquipmentType type)
        {
            return _equipment.ContainsKey(type);
        }

        public KeyValuePair<EquipmentType, ItemModule.Item>[] GetItems()
        {
            return _equipment.Select(item => new KeyValuePair<EquipmentType, ItemModule.Item>(item.Key, item.Value)).ToArray();
        }

        public void EquipItem(ItemModule.Item item)
        {
            var type = item.GetComponent<Component_EquipmentType>().Type;
            
            if (HasItem(type)) UnequipItem(type);

            _equipment.Add(type, item);
            Debug.Log(item.Name);
            OnItemEquipped?.Invoke(item);
        }

        public void UnequipItem(ItemModule.Item item)
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