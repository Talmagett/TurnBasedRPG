using System;
using System.Collections.Generic;
using Sirenix.Utilities;
using UnityEngine;
using Zenject;

namespace Game.Meta.Items.Scripts.ItemModule
{
    [Serializable]
    public class ItemsContainer
    {
        [SerializeField] private ItemConfig[] itemConfigs;

        private readonly Dictionary<string, ItemConfig> _items=new ();

        public void Initialize()
        {
            itemConfigs.ForEach(t => _items.Add(t.item.Name, t));
        }

        public Item GetItem(string name)
        {
            return _items.TryGetValue(name, out var item) ? item.item.Clone() : null;
        }
    }
}