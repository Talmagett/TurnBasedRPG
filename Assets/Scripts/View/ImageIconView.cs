using UnityEngine;
using UnityEngine.UI;

namespace Map.UI
{
    public class ImageIconView : MonoBehaviour
    {
        [SerializeField] private Image characterIcon;

        public void SetIcon(Sprite icon)
        {
            characterIcon.sprite = icon;
        }
    }
}