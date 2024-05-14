using System.Linq;
using Game.App.SaveSystem.GameEngine.Objects;
using Game.App.SaveSystem.GameEngine.Systems;
using Game.App.SaveSystem.SaveSystem;
using UnityEngine;

namespace Game.App.SaveSystem.SaveLoaders
{
    public class InventorySaveLoader : SaveLoader<InventoryItemData[], ItemsManager>
    {
        protected override void SetupData(ItemsManager service, InventoryItemData[] loadedUnitsDataArray)
        {
            service.SetLoadedItems(loadedUnitsDataArray);
        }

        protected override InventoryItemData[] ConvertToData(ItemsManager service)
        {
            var items = service.GetPlayerItems().ToArray();
            Debug.Log($"<color=green>{items.Length} units was saved</color>");
            var itemsData = new InventoryItemData[items.Length];
            for (var i = 0; i < items.Length; i++)
            {
                itemsData[i].itemID=items[i].Name;
            }

            return itemsData;
        }

        protected override void SetupByDefault(ItemsManager service)
        {
            service.SetDefaultItems();
        }
    }
}