using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Modules.Items.Scripts.ItemModule
{
    public class ItemFullView : MonoBehaviour
    {
        [SerializeField] private Image image;
        [SerializeField] private TMP_Text itemNameText;
        [SerializeField] private TMP_Text itemDescriptionText;

        public void SetName(string itemName)
        {
            itemNameText.text = itemName;
        }
        
        public void SetDescription(string itemName)
        {
            itemDescriptionText.text = itemName;
        }

        public void SetIcon(Sprite icon)
        {
            image.sprite = icon;
        }
    }
}