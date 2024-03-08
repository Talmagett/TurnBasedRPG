using UnityEngine;

namespace Map.Characters.Interactions.Environment
{
    public class AttackableInteraction : MonoBehaviour
    {
        [SerializeField] private WeaponType weaponType;
        [SerializeField] private int level;
        
        public bool CanAttack(WeaponType characterWeaponType, int characterWeaponLevel)
        {
            print("checking");
            return weaponType == characterWeaponType && level <= characterWeaponLevel;
        }

        public void Destroy()
        {
            gameObject.SetActive(false);
        }
    }
}