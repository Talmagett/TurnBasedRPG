using UnityEngine;

namespace Game.Gameplay.Interactables.Scripts.Environment
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