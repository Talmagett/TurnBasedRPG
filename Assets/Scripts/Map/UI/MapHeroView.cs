using Map.Characters;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Map.UI
{
    public class MapHeroView : MonoBehaviour
    {
        [SerializeField] private Image characterIcon;
        [SerializeField] private Image characterHealth;
        
        public void SetCharacterIcon(Sprite icon)
        {
            characterIcon.sprite = icon;
        }

        public void SetCharacterHealth(float percentage)
        {
            characterHealth.fillAmount = percentage;
        }
    }
}