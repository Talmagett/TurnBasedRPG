using Modules.Items.Scripts.Inventory;
using Modules.Items.Scripts.ItemModule;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace UI.Controllers.TabMenu
{
    public class UIInventoryController : MonoBehaviour
    {
        [SerializeField] private InventoryView inventoryView;
        
        [SerializeField] private ItemFullView itemFullView;

        [Title("DEBUG")]
        [Button]
        
        public void AddItem(ItemConfig itemConfig)
        {
            _inventory.AddItem(itemConfig.item.Clone());
        }
        
        
        private Inventory _inventory;
        
        [Inject]
        public void Ctor(Inventory inventory)
        {
            _inventory = inventory;
        }
        
        public void Show()
        {
            InventoryPresenter inventoryPresenter = new InventoryPresenter(_inventory,inventoryView,itemFullView);
        }
    }
}