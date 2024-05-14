using Game.Meta.Items.Scripts.ItemModule;
using UnityEngine;

namespace Game.Meta.Inventory.Inventory
{
    public class InventoryView : MonoBehaviour
    {
        [SerializeField] private ItemView itemViewPrefab;
        [SerializeField] private Transform parent;

        public ItemView SpawnItem()
        {
            var item = Instantiate(itemViewPrefab, parent);
            return item;
        }

        public void ClearField()
        {
            while (parent.childCount > 0) DestroyImmediate(parent.GetChild(0).gameObject);
        }
    }
}