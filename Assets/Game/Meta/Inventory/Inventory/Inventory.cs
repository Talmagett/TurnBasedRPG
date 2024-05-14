using System;
using System.Collections.Generic;
using System.Linq;
using Game.Meta.Items.Scripts.ItemModule;
using Sirenix.OdinInspector;

namespace Game.Meta.Inventory.Inventory
{
    public sealed class Inventory
    {
        [ShowInInspector] [ReadOnly] private List<Item> _items;

        public Inventory(params Item[] items)
        {
            _items = new List<Item>(items);
        }

        public event Action<Item> OnItemAdded;
        public event Action<Item> OnItemRemoved;

        public void Setup(params Item[] items)
        {
            _items = new List<Item>(items);
        }

        public void AddItem(Item item)
        {
            if (!_items.Contains(item))
            {
                _items.Add(item);
                OnItemAdded?.Invoke(item);
            }
        }

        public void RemoveItem(Item item)
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

        public List<Item> GetItems()
        {
            return _items.ToList();
        }

        public bool FindItem(string name, out Item result)
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