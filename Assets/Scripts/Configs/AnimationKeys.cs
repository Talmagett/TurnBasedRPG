using System;
using UnityEngine;

namespace Actors
{
    public static class AnimationKeys
    {
        public static int GetAnimation(Animation animation)
        {
            return animation switch
            {
                Animation.Attack1 => Attack1,
                Animation.Attack2 => Attack2,
                Animation.Heal => Heal,
                Animation.Hit => Hit,
                Animation.Death => Death,
                Animation.IsMoving => isMoving,
                _ => Idle
            };
        }
        
        private static readonly int Attack1 = Animator.StringToHash("Attack1");
        private static readonly int Attack2 = Animator.StringToHash("Attack2");
        private static readonly int Heal = Animator.StringToHash("Heal");
        private static readonly int Hit = Animator.StringToHash("Hit");
        private static readonly int Death = Animator.StringToHash("Death");
        private static readonly int Idle = Animator.StringToHash("Idle");
        private static readonly int isMoving = Animator.StringToHash("IsMoving");

        public enum Animation
        {
            Attack1,
            Attack2,
            Heal,
            Hit,
            IsMoving,
            Death
        }
    }
}