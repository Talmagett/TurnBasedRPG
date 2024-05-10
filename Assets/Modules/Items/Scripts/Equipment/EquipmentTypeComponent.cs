using UnityEngine;

namespace Modules.Items.Scripts.Equipment
{
    public class EquipmentTypeComponent
    {
        [field: SerializeField] public EquipmentType Type { get; private set; }

        public EquipmentTypeComponent(EquipmentType type)
        {
            Type = type;
        }
    }
}