using UnityEngine;

namespace Modules.Items.Scripts.Equipment
{
    public class Component_EquipmentType
    {
        [field: SerializeField] public EquipmentType Type { get; private set; }

        public Component_EquipmentType(EquipmentType type)
        {
            Type = type;
        }
    }
}