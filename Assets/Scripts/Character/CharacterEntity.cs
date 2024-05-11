using Entities;
using UnityEngine;

namespace Character
{
    public sealed class CharacterEntity : MonoEntityBase
    {
        public AnimatorDispatcher AnimatorDispatcher { get; }

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