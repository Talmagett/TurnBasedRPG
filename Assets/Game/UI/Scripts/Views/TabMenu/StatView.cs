using TMPro;
using UnityEngine;

namespace Game.UI.Scripts.Views.TabMenu
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