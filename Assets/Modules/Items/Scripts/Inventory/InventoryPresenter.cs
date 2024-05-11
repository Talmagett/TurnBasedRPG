using System;
using Modules.Items.Scripts.ItemModule;

namespace Modules.Items.Scripts.Inventory
{
    public class InventoryPresenter : IDisposable
    {
        private readonly Inventory _inventory;
        private readonly InventoryView _inventoryView;
        private readonly ItemFullView _itemFullView;
        private readonly ItemFullPresenter _itemFullPresenter;

        public InventoryPresenter(Inventory inventory, InventoryView inventoryView, ItemFullView itemFullView)
        {
            _inventory = inventory;
            _inventoryView = inventoryView;
            _itemFullView = itemFullView;

            _inventoryView.ClearField();
            
            foreach (var item in _inventory.GetItems())
            {
                var itemPresenter = new ItemPresenter(item,_inventoryView.SpawnItem());
                
                //OpenItemFullDataWindow
            }
        }

        private void OpenItemFullDataWindow(ItemPresenter item)
        {
            //_itemFullPresenter.
        }

        public void Dispose()
        {
            
        }
    }
}