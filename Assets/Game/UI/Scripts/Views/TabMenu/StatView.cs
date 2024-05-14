using TMPro;
using UnityEngine;

namespace UI.Views.TabMenu
{
    public class StatView : MonoBehaviour
    {
        [SerializeField] private TMP_Text statValue;

        public void SetValue(string value)
        {
            statValue.text = value;
        }
    }
}