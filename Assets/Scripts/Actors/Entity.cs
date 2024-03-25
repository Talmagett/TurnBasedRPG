using Atomic.Objects;
using UnityEngine;

namespace Actors
{
    public abstract class Entity : AtomicObject
    {
        [SerializeField] private string id;
    
        public virtual void Awake()
        {
            AddProperty("ID", id);
            AddProperty("Transform", transform);
            AddProperty("GameObject", gameObject);
        }
    }
}