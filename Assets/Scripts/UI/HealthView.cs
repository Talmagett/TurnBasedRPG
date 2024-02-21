using Components;
using Components.Stats;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace UI
{
    public class HealthView : MonoBehaviour
    {
        [SerializeField] private Image image;

        public void SetHealthFill(float percentage)
        {
            image.fillAmount = percentage;
        }
    }
}