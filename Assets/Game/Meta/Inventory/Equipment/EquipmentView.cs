using UnityEngine;
using UnityEngine.UI;

namespace Game.Meta.Inventory.Equipment
{
    public class EquipmentView : MonoBehaviour
    {
        [SerializeField] private Image defaultIconImage;
        [SerializeField] private Image iconImage;
        
        public void SetIcon(Sprite icon = null)
        {
            defaultIconImage.gameObject.SetActive(icon==null);
            iconImage.gameObject.SetActive(icon!=null);
            iconImage.sprite = icon;
        }
    }
}