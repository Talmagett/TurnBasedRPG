using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Modules.Items.Scripts.Equipment
{
    public class EquipmentView : MonoBehaviour
    {
        [SerializeField] private EquipmentStack[] equipmentStack;

        public void SetIcon(EquipmentType type, Sprite icon = null)
        {
            equipmentStack.FirstOrDefault(t => t.type == type)!.icon.sprite = icon;
        }
        
        [System.Serializable]
        public class EquipmentStack
        {
            public EquipmentType type;
            public Image icon;
        }
    }
}