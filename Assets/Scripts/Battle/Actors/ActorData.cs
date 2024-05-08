using System.Collections.Generic;
using Atomic.Elements;
using Atomic.Objects;
using Battle.Actors.Model;
using Configs;
using Configs.Character;
using Configs.Enums;
using PrimeTween;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Battle.Actors
{
    public class ActorData : AtomicObject
    {
        [field: SerializeField] public BodyParts BodyParts { get; private set; }
        //private readonly AtomicVariable<int> _cooldown = new();
        public Animator Animator { get; private set; }
        public AnimatorDispatcher AnimatorDispatcher { get; private set; }

        public virtual void Awake()
        {
            AddProperty(AtomicAPI.Transform, transform);
            AddProperty(AtomicAPI.GameObject, gameObject);

            Animator = GetComponentInChildren<Animator>();
            AnimatorDispatcher = Animator.GetComponent<AnimatorDispatcher>();
        }

        public void Select()
        {
            Tween.Scale(transform, Vector3.one * 1.2f, 0.3f);
            Tween.Position(transform, transform.position + transform.forward * 2, 0.3f);
        }

        public void Deselect()
        {
            Tween.Scale(transform, Vector3.one, 0.3f);
            Tween.Position(transform, transform.position - transform.forward * 2, 0.3f);
        }

        public void DestroySelf()
        {
            Animator.SetTrigger(AnimationKey.GetAnimation(AnimationKey.Animation.Death));
            Debug.Log("destroyed"+gameObject.name);
            Destroy(gameObject);
        }
    }
}