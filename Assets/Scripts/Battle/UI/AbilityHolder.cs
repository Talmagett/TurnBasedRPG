using Battle.Abilities;
using Battle.AbilityContainers;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Battle.UI
{
    public class AbilityHolder : MonoBehaviour
    {
        [SerializeField] private TMP_Text title;
        [SerializeField] private Image[] usagesImages;
        [SerializeField] private Button button;
        
        public void SetData(AbilityContainer abilityContainer,Ability ability)
        {
            title.text = abilityContainer.Name;
            for (int i = 0; i < abilityContainer.Usage; i++)
            {
                usagesImages[i].gameObject.SetActive(i<abilityContainer.Usage);
            }
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(ability.StartAbility);
        }
    }
}