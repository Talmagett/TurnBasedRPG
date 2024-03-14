using UnityEngine;
using UnityEngine.UI;

namespace View
{
    public class SliderView : MonoBehaviour
    {
        [SerializeField] private Image characterHealth;

        public void SetFill(float percentage)
        {
            characterHealth.fillAmount = percentage;
        }
    }
}