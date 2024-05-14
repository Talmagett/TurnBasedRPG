using System;
using Game.Meta.Items.Scripts.ItemModule;

namespace Game.Meta.Inventory.Inventory
{
    public class ItemFullPresenter : IDisposable
    {
        private readonly Item _item;
        private readonly ItemFullView _itemFullView;

        public ItemFullPresenter(Item item, ItemFullView itemFullView)
        {
            _item = item;
            _itemFullView = itemFullView;
        }

        public void Dispose()
        {
        }
    }
}