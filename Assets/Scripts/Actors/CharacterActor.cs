using Atomic.Elements;
using Atomic.Objects;
using UnityEngine;

namespace Actors
{
    public class CharacterActor : AtomicObject
    {        
        [SerializeField] private string id;
        [SerializeField] private AtomicVariable<Animator> animator;
    
        public virtual void Awake()
        {
            AddProperty("ID", id);
            AddProperty("Transform", transform);
            AddProperty("GameObject", gameObject);
            AddProperty("Animator", animator);
        }
    }
}