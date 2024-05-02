using TMPro;
using UnityEngine;

namespace Visual.UI.Battle.UI
{
    public sealed class TextWidget : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI text;

        public void SetText(string value)
        {
            text.text = value;
        }
    }
}