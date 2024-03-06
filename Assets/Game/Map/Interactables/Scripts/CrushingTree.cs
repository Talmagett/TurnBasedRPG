using UnityEngine;

namespace Game.Map.Interactables.Scripts
{
    public class CrushingTree : MonoBehaviour, ICrushable
    {
        
        public void Crush()
        {
            gameObject.SetActive(false);
        }
    }
}