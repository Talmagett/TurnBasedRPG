using UnityEngine;

namespace Game.Map.Interactables.Scripts
{
    public class BurnableBush : MonoBehaviour, IBurnable
    {
        public void Burn()
        {
            gameObject.SetActive(false);
        }
    }
}