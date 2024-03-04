using UnityEngine;

namespace Game.Map.Scripts
{
    public class PlayerCharacter : BaseCharacter
    {
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