using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Game.Meta.Inventory.Equipment
{
    public class EquipmentView : MonoBehaviour
    {
        [SerializeField] private EquipmentStack[] equipmentStack;

        public void SetIcon(EquipmentType type, Sprite icon = null)
        {
            equipmentStack.FirstOrDefault(t => t.type == type)!.icon.sprite = icon;
        }

        [Serializable]
        public class EquipmentStack
        {
            public EquipmentType type;
            public Image icon;
        }
    }
}