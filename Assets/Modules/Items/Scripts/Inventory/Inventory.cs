using System;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;

namespace Modules.Items.Scripts.Inventory
{
    //Нельзя менять!
    [Serializable]
    public sealed class Inventory
    {
        [ShowInInspector] [ReadOnly] private List<ItemModule.Item> items;

        public Inventory(params ItemModule.Item[] items)
        {
            this.items = new List<ItemModule.Item>(items);
        }

        public event Action<ItemModule.Item> OnItemAdded;
        public event Action<ItemModule.Item> OnItemRemoved;

        [Button]
        public void Setup(params ItemModule.Item[] items)
        {
            this.items = new List<ItemModule.Item>(items);
        }
        [Button]

        public void AddItem(ItemModule.Item item)
        {
            if (!items.Contains(item))
            {
                items.Add(item);
                OnItemAdded?.Invoke(item);
            }
        }
        [Button]

        public void RemoveItem(ItemModule.Item item)
        {
            if (items.Remove(item)) OnItemRemoved?.Invoke(item);
        }
        [Button]

        public void RemoveItems(string name, int count)
        {
            for (var i = 0; i < count; i++) RemoveItem(name);
        }
        [Button]

        public void RemoveItem(string name)
        {
            if (FindItem(name, out var item)) RemoveItem(item);
        }

        public List<ItemModule.Item> GetItems()
        {
            return items.ToList();
        }

        public bool FindItem(string name, out ItemModule.Item result)
        {
            foreach (var inventoryItem in items)
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
            return items.Count(it => it.Name == item);
        }
    }
}