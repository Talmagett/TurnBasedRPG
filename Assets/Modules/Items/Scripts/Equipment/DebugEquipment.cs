using Modules.Items.Scripts.Item;
using Modules.Items.Scripts.ItemModule;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Modules.Items.Scripts.Equipment
{
    public class DebugEquipment : MonoBehaviour
    {
        private Equipment _equipment;

        [Inject]
        public void Construct(Equipment equipment)
        {
            _equipment = equipment;
        }

        [Button]
        public void EquipItem(ItemConfig itemConfig)
        {
            var item = itemConfig.item.Clone();
            var equipmentType = item.GetComponent<EquipmentTypeComponent>();

            //_equipment.EquipItem(equipmentType.Type,item);
        }

        [Button]
        public void UnequipItem(ItemConfig itemConfig)
        {
            var item = itemConfig.item.Clone();
            var equipmentType = item.GetComponent<EquipmentTypeComponent>();
            
            //_equipment.UnequipItem(equipmentType.Type,item);
        }
    }
}