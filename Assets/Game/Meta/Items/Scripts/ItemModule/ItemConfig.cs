using Sirenix.OdinInspector;
using UnityEngine;

namespace Game.Meta.Items.Scripts.ItemModule
{
    [CreateAssetMenu(
        fileName = "ItemConfig",
        menuName = "SO/Inventory/New InventoryItemConfig"
    )]
    public sealed class ItemConfig : SerializedScriptableObject
    {
        [SerializeField] public Item item;
    }
}