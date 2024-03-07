using UnityEngine;

namespace Map.Interactables
{
    public class ShootableMechanism : MonoBehaviour, IShootable
    {
        public void Shoot()
        {
            gameObject.SetActive(false);
        }
    }
}