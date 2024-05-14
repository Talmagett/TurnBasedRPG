using PrimeTween;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Game.UI.Scripts.Battle.View
{
    public class ResourceBar : MonoBehaviour
    {
        [SerializeField] private Image barImage;
        [SerializeField] private TMP_Text resourceText;

        public void SetText(string text)
        {
            resourceText.text = text;
        }

        public void SetTextWithAnimation(string text, float duration)
        {
            Tween.ShakeScale(resourceText.transform, Vector3.one * 1.5f, duration);
            resourceText.text = text;
        }

        public void SetFill(float percentage)
        {
            Tween.UIFillAmount(barImage, percentage, 0.3f);
        }
    }
}