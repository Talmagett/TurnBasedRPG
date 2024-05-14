using UnityEngine;
using UnityEngine.UI;

namespace Game.UI.Scripts.Views.Map
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