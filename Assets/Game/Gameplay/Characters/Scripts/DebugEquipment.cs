using Game.Gameplay.Game.Heroes;
using Game.Meta.Inventory.Equipment;
using Game.Meta.Items.Scripts.ItemModule;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Game.Gameplay.Characters.Scripts
{
    public class DebugEquipment : MonoBehaviour
    {
        private HeroParty _heroParty;

        [Inject]
        public void Construct(HeroParty heroParty)
        {
            _heroParty = heroParty;
        }

        [Button]
        public void EquipItem(int index, ItemConfig itemConfig)
        {
            var item = itemConfig.item.Clone();
            _heroParty.HeroDataArray[index].Get<Equipment>().EquipItem(item);
        }

        [Button]
        public void UnequipItem(int index, ItemConfig itemConfig)
        {
            var item = itemConfig.item.Clone();
            _heroParty.HeroDataArray[index].Get<Equipment>().UnequipItem(item);
        }
    }
}