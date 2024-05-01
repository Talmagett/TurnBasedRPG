using TMPro;
using UnityEngine;

namespace Battle.EventBus.Entities.Common.UI
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