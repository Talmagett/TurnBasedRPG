using UnityEngine;

namespace Game.Meta.Inventory.Equipment
{
    public class Component_EquipmentType
    {
        public Component_EquipmentType(EquipmentType type)
        {
            Type = type;
        }

        [field: SerializeField] public EquipmentType Type { get; private set; }
    }
}