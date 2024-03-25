using Atomic.Elements;
using UnityEngine;

namespace Actors
{
    public class MapActor : Entity
    {        
        [SerializeField] private AtomicVariable<CollisionTag> collisionTag;
        [SerializeField] private AtomicVariable<Animator> animator;

        public override void Awake() 
        {
            base.Awake();
            AddProperty("CollisionTag", collisionTag);
            AddProperty("Animator", animator);
        }
    }
}