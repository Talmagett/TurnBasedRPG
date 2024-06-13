using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI.Scripts.Views.TabMenu
{
    public class HeroPersonalDataView : MonoBehaviour
    {
        [SerializeField] private TMP_Text heroName;
        [SerializeField] private TMP_Text heroDescription;
        [SerializeField] private Image heroIcon;
        
        public void SetName(string newName)
        {
            heroName.text = newName;
        }

        public void SetDescription(string description)
        {
            heroDescription.text = description;
        }

        public void SetIcon(Sprite icon)
        {
            heroIcon.sprite = icon;
        }
    }
}