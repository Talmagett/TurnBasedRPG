using UnityEngine;

namespace Map.Interactions.Environment
{
    public class AttackableInteraction : Interactable
    {
        [SerializeField] private string requiredSkill;
        [SerializeField] private int level;

        public void DestroySelf()
        {
            gameObject.SetActive(false);
        }

        public override void Interact(Transform transform)
        {
            DestroySelf();
        }
    }
}