using System;
using Modules.Items.Scripts.ItemModule;

namespace Modules.Items.Scripts.Inventory
{
    public class ItemFullPresenter : IDisposable
    {
        private readonly ItemModule.Item _item;
        private readonly ItemFullView _itemFullView;

        public ItemFullPresenter(ItemModule.Item item, ItemFullView itemFullView)
        {
            _item = item;
            _itemFullView = itemFullView;
        }
        
        public void Dispose()
        {
            
        }
    }
}