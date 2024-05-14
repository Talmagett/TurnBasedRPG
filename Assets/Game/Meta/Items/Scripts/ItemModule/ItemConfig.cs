using UnityEngine;

namespace Game.Meta.Items.Scripts.ItemModule
{
    [CreateAssetMenu(
        fileName = "ItemConfig",
        menuName = "SO/Inventory/New InventoryItemConfig"
    )]
    public sealed class ItemConfig : ScriptableObject
    {
        [SerializeField] public Item item;
    }
}