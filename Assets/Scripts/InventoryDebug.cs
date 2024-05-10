using Modules.Items.Scripts.Inventory;
using Modules.Items.Scripts.ItemModule;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

public class InventoryDebug : MonoBehaviour
{
        [SerializeField] private Inventory _inventory;
        
        [Inject]
        public void Ctor(Inventory inventory)
        {
                _inventory = inventory;
        }

        [Button]
        public void AddItem(ItemConfig itemConfig)
        {
               _inventory.AddItem(itemConfig.item.Clone()); 
        }
}