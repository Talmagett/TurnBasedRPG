using Game.Meta.Items.Scripts.ItemModule;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Game.Meta.Inventory.Inventory
{
    public class DebugInventory : MonoBehaviour
    {
        private Inventory _inventory;
        
        [Inject]
        public void Ctor(Inventory inventory)
        {
            _inventory = inventory;
        }

        [Button]
        public void AddItem(ItemConfig item)
        {
            _inventory.AddItem(item.item.Clone());
        }

        [Button]
        public void RemoveItem(ItemConfig item)
        {
            _inventory.RemoveItem(item.item.Name);
        }
    }
}