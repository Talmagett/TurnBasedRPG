using System;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;

namespace Modules.Items.Scripts.Inventory
{
    public sealed class Inventory
    {
        [ShowInInspector] [ReadOnly] private List<ItemModule.Item> _items;

        public Inventory(params ItemModule.Item[] items)
        {
            _items = new List<ItemModule.Item>(items);
        }

        public event Action<ItemModule.Item> OnItemAdded;
        public event Action<ItemModule.Item> OnItemRemoved;

        public void Setup(params ItemModule.Item[] items)
        {
            _items = new List<ItemModule.Item>(items);
        }

        public void AddItem(ItemModule.Item item)
        {
            if (!_items.Contains(item))
            {
                _items.Add(item);
                OnItemAdded?.Invoke(item);
            }
        }

        public void RemoveItem(ItemModule.Item item)
        {
            if (_items.Remove(item)) OnItemRemoved?.Invoke(item);
        }

        public void RemoveItems(string name, int count)
        {
            for (var i = 0; i < count; i++) RemoveItem(name);
        }

        public void RemoveItem(string name)
        {
            if (FindItem(name, out var item)) RemoveItem(item);
        }

        public List<ItemModule.Item> GetItems()
        {
            return _items.ToList();
        }

        public bool FindItem(string name, out ItemModule.Item result)
        {
            foreach (var inventoryItem in _items)
                if (inventoryItem.Name == name)
                {
                    result = inventoryItem;
                    return true;
                }

            result = null;
            return false;
        }

        public int GetCount(string item)
        {
            return _items.Count(it => it.Name == item);
        }
    }
}