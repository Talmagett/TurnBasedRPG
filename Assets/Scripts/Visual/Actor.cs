using Atomic.Elements;
using Atomic.Objects;
using UnityEngine;

namespace Visual
{
    public class Actor : AtomicObject
    {
        [SerializeField] private string id;
        
        [SerializeField] private AtomicVariable<Animator> animator;
        [SerializeField] private AtomicVariable<CollisionTag> collisionTag;
        
        private void Awake()
        {
            AddProperty("ID", id);
            AddProperty("Animator", animator);
            AddProperty("Transform", transform);
            AddProperty("CollisionTag", collisionTag);
        }
    }
}