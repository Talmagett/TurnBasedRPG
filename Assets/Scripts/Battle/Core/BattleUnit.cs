using System;
using Battle.Abilities;
using UnityEngine;

namespace Battle.Core
{
    public class BattleUnit : MonoBehaviour
    {
        public static event Action<BattleUnit> OnSelected;
        
        [Space]
        [SerializeField] private Transform abilitiesParent;
        [SerializeField] private GameObject selectedVisual;
        public bool IsMoving { get; private set; }
        [field:SerializeField] public BodyParts BodyParts { get; private set; }

        public Ability[] Abilities { get; private set; }
        
        public void Init()
        {
            EndTurn();
            Abilities = new Ability[abilitiesParent.childCount];
            
            for (int i = 0; i < abilitiesParent.childCount; i++)
            {
                Abilities[i] = abilitiesParent.GetChild(i).GetComponent<Ability>();
                Abilities[i].Init(this,ServiceLocator.Instance.GetPlayerController());
            }
        }

        public void StartTurn()
        {
            IsMoving = true;
            selectedVisual.SetActive(true);
            OnSelected?.Invoke(this);
        }

        public void EndTurn()
        {
            IsMoving = false;
            selectedVisual.SetActive(false);
        }
    }
}