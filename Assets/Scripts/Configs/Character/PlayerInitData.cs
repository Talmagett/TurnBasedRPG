using Modules.Items.Scripts.ItemModule;
using UnityEngine;

namespace Configs.Character
{
    [CreateAssetMenu(menuName = "SO/AbilitiesList", fileName = "AbilitiesList", order = 0)]
    public class PlayerInitData : ScriptableObject
    {
        [SerializeField] private ItemConfig[] baseItemsForInventory;
        
        public Item[] GetItems()
        {
            var items = new Item[baseItemsForInventory.Length];
            for (var i = 0; i < baseItemsForInventory.Length; i++) items[i] = baseItemsForInventory[i].item.Clone();

            return items;
        }
    }
}