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


        private Inventory _inventory;

        [Title("DEBUG")]
        [Button]
        public void AddItem(ItemConfig itemConfig)
        {
            _inventory.AddItem(itemConfig.item.Clone());
        }

        [Inject]
        public void Ctor(Inventory inventory)
        {
            _inventory = inventory;
        }

        public void Show()
        {
            var inventoryPresenter = new InventoryPresenter(_inventory, inventoryView, itemFullView);
        }
    }
}