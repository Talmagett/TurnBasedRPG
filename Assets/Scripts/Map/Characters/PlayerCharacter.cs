using Map.Interactions.Environment;
using UnityEngine;

namespace Map.Characters
{
    public class PlayerCharacter : BaseCharacter
    {
        [SerializeField] private Weapon weapon;

        public Weapon GetWeapon()
        {
            return weapon;
        }

        public void Deactivate()
        {
            gameObject.SetActive(false);
        }

        public void Activate()
        {
            gameObject.SetActive(true);
        }
    }
}