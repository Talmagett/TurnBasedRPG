using Battle.Abilities;
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
        
        public void SetData(Ability ability)
        {
            title.text = ability.Name;
            for (int i = 0; i < ability.Usage; i++)
            {
                usagesImages[i].gameObject.SetActive(i<ability.Usage);
            }
            button.onClick.RemoveAllListeners();
            button.onClick.AddListener(ability.StartAbility);
        }
    }
}