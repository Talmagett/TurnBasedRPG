using Game.GameEngine.Entities.Scripts.MonoBehaviours;
using UnityEngine;

namespace Game.Gameplay.Characters.Scripts
{
    public sealed class CharacterEntity : MonoEntityBase
    {
        public void Awake()
        {
            var animator = GetComponentInChildren<Animator>();
            var animatorDispatcher = animator.GetComponent<AnimatorDispatcher>();

            Add(transform);
            Add(gameObject);
            Add(animator);
            Add(animatorDispatcher);
        }
    }
}