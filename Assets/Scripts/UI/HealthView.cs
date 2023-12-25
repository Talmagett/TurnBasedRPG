using Components;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace UI
{
    public class HealthView : MonoBehaviour
    {
        [SerializeField] private Health health;
        [SerializeField] private Image image;

        private void OnEnable()
        {
            health.OnHealthChangedPercentage += HealthOnChangedPercentage;
        }
        private void OnDisable()
        {
            health.OnHealthChangedPercentage -= HealthOnChangedPercentage;
        }
        private void HealthOnChangedPercentage(float percentage)
        {
            image.fillAmount = percentage;
        }
    }
}