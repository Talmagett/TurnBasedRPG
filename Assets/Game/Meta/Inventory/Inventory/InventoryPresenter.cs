using System;
using Game.Meta.Items.Scripts.ItemModule;

namespace Game.Meta.Inventory.Inventory
{
    public class InventoryPresenter : IDisposable
    {
        private readonly Inventory _inventory;
        private readonly InventoryView _inventoryView;
        private readonly ItemFullPresenter _itemFullPresenter;
        private readonly ItemFullView _itemFullView;

        public InventoryPresenter(Inventory inventory, InventoryView inventoryView, ItemFullView itemFullView)
        {
            _inventory = inventory;
            _inventoryView = inventoryView;
            _itemFullView = itemFullView;

            _inventoryView.ClearField();

            foreach (var item in _inventory.GetItems())
            {
                var itemPresenter = new ItemPresenter(item, _inventoryView.SpawnItem());

                //OpenItemFullDataWindow
            }
        }

        public void Dispose()
        {
        }

        private void OpenItemFullDataWindow(ItemPresenter item)
        {
            //_itemFullPresenter.
        }
    }
}