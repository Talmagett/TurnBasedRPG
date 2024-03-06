using UnityEngine;

namespace Game.Map.Scripts
{
    public class PlayerCharacter : BaseCharacter
    {
        [SerializeField] private Weapon weapon;
        public Weapon GetWeapon() => weapon;
        
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