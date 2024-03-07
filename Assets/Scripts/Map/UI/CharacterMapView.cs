using Map.Characters;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace Map.UI
{
    public class CharacterMapView : MonoBehaviour
    {
        [SerializeField] private PlayerCharacter playerCharacter;
        
        [SerializeField] private Image characterIcon;
        [SerializeField] private Image characterHealth;

        private void OnEnable()
        {
            playerCharacter.Health.Subscribe(UpdateHealth);
        }

        private void UpdateHealth(int health)
        {
            SetCharacterHealth(((float)health)/playerCharacter.MaxHealth.Value);
        }

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