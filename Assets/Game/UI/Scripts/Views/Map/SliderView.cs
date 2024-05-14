using UnityEngine;
using UnityEngine.UI;

namespace Game.UI.Scripts.Views.Map
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