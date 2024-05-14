using UnityEngine;
using UnityEngine.UI;

namespace UI.Views.Map
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