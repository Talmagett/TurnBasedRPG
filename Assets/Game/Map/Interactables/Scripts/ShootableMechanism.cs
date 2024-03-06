using UnityEngine;

namespace Game.Map.Interactables.Scripts
{
    public class ShootableMechanism : MonoBehaviour, IShootable
    {
        public void Shoot()
        {
            gameObject.SetActive(false);
        }
    }
}