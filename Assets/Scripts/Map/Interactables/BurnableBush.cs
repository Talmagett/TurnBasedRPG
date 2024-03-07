using UnityEngine;

namespace Map.Interactables
{
    public class BurnableBush : MonoBehaviour, IBurnable
    {
        public void Burn()
        {
            gameObject.SetActive(false);
        }
    }
}