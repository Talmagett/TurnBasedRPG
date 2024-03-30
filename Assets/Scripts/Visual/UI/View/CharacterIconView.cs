using UnityEngine;
using UnityEngine.UI;

namespace Visual.UI.View
{
    public class CharacterIconView : MonoBehaviour
    {
        [SerializeField] private Image characterIcon;

        public void SetIcon(Sprite icon)
        {
            characterIcon.sprite = icon;
        }
    }
}