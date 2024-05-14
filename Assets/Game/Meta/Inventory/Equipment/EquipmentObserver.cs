using System.Collections.Generic;
using System.Linq;
using Sirenix.Utilities;
using UnityEngine;

namespace Game.Meta.Inventory.Equipment
{
    public class EquipmentObserver
    {
        private readonly Equipment _equipment;
        private readonly EquipmentAdapter[] _equipmentAdapters;
        
        public EquipmentObserver(Equipment equipment, EquipmentAdapter[] equipmentAdapters)
        {
            _equipment = equipment;
            _equipmentAdapters = equipmentAdapters;
            foreach (var equipmentAdapter in _equipmentAdapters)
            {
                var items = _equipment.GetItems();
                var equipmentPair = items.FirstOrDefault(t => t.Key == equipmentAdapter.equipmentType);
                equipmentAdapter.equipmentView.SetIcon(equipmentPair.Value?.Icon);
            }
            _equipment.GetItems().ForEach(t => _equipmentAdapters.FirstOrDefault(e=>e.equipmentType==t.Key).equipmentView.SetIcon(t.Value.Icon));
        }
        
        [System.Serializable]
        public class EquipmentAdapter
        {
            public EquipmentType equipmentType;
            public EquipmentView equipmentView;
        }
    }
}