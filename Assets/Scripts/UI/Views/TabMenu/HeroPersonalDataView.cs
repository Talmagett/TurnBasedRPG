using TMPro;
using UnityEngine;

namespace Visual.UI.TabMenu
{
    public class HeroPersonalDataView : MonoBehaviour
    {
        [SerializeField] private TMP_Text heroName;
        [SerializeField] private TMP_Text heroDescription;

        public void SetName(string newName)
        {
            heroName.text = newName;
        }

        public void SetDescription(string description)
        {
            heroDescription.text = description;
        }
    }
}