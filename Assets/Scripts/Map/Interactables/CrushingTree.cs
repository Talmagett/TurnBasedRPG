using UnityEngine;

namespace Map.Interactables
{
    public class CrushingTree : MonoBehaviour, ICrushable
    {
        
        public void Crush()
        {
            gameObject.SetActive(false);
        }
    }
}