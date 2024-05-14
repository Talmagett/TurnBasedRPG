using System.Collections.Generic;
using System.Linq;
using Game.App.SaveSystem.GameEngine.Objects;
using Game.Meta.Inventory.Inventory;
using Game.Meta.Items.Scripts.ItemModule;
using Sirenix.Utilities;
using Zenject;

namespace Game.App.SaveSystem.GameEngine.Systems
{
    public class ItemsManager
    {
        private readonly Inventory _inventory;
        private readonly ItemConfig[] _defaultItemConfigs;
        private readonly Dictionary<string, ItemConfig> _items=new ();

        [Inject]
        public ItemsManager(Inventory inventory, ItemConfig[] defaultItemConfigs)
        {
            _inventory = inventory;
            _defaultItemConfigs = defaultItemConfigs;
        }

        public void InitializeAllItems(ItemConfig[] itemConfigs)
        {
            itemConfigs.ForEach(t => _items.Add(t.item.Name, t));
        }

        public List<Item> GetPlayerItems() => _inventory.GetItems();
        public void SetLoadedItems(InventoryItemData[] loadedUnitsDataArray)
        {
            var loadedItems = loadedUnitsDataArray.Select(data => _items[data.itemID].item.Clone()).ToArray();
            _inventory.Setup(loadedItems);
        }

        public void SetDefaultItems()
        {
            var items = _defaultItemConfigs.Select(t=>t.item.Clone()).ToArray();
            _inventory.Setup(items);
        }
    }
}