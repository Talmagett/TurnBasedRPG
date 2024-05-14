using System.Collections.Generic;
using System.Linq;
using Game.App.SaveSystem.GameEngine.Objects;
using Game.Meta.Inventory.Inventory;
using Game.Meta.Items.Scripts.ItemModule;
using Zenject;

namespace Game.App.SaveSystem.GameEngine.Systems
{
    public class ItemsManager
    {
        private readonly Inventory _inventory;
        private readonly ItemsContainer _itemsContainer;
        private readonly ItemConfig[] _defaultItemConfigs;

        [Inject]
        public ItemsManager(Inventory inventory, ItemsContainer itemsContainer, ItemConfig[] defaultItemConfigs)
        {
            _inventory = inventory;
            _itemsContainer = itemsContainer;
            _defaultItemConfigs = defaultItemConfigs;
        }
        
        public List<Item> GetPlayerItems() => _inventory.GetItems();
        
        public void SetLoadedItems(InventoryItemData[] loadedUnitsDataArray)
        {
            var loadedItems = loadedUnitsDataArray.Select(data => _itemsContainer.GetItem(data.itemID)).ToArray();
            _inventory.Setup(loadedItems);
        }

        public void SetDefaultItems()
        {
            var items = _defaultItemConfigs.Select(t=>t.item.Clone()).ToArray();
            _inventory.Setup(items);
        }
    }
}