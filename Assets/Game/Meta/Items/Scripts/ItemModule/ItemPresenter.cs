using System;
using UnityEngine;

namespace Modules.Items.Scripts.ItemModule
{
    public class ItemPresenter : IDisposable
    {
        private readonly Item _item;
        private readonly ItemView _itemView;
        private readonly Action _onPressed;
        
        public ItemPresenter(Item item, ItemView itemView, Action onPressed=null)
        {
            _item = item;
            _itemView = itemView;
            _onPressed = onPressed;

            _itemView.SetIcon(item.Icon);
            _itemView.OnPressed += _onPressed;
        }

        public void Dispose()
        {
            _itemView.OnPressed -= _onPressed;
        }
    }
}