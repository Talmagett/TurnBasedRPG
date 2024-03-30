using Atomic.Elements;
using Atomic.Objects;
using Battle;
using Battle.Characters;
using Cysharp.Threading.Tasks;
using Data;
using Sirenix.OdinInspector;
using UnityEngine;
using Zenject;

namespace Actors
{
    public class ActorData : AtomicObject
    {
        [field: SerializeField] public CharacterConfig Config { get; private set; }
        [field: SerializeField] public Animator Animator { get; private set; }
    
        public Owner Owner { get; private set; }
        [ReadOnly]
        public SharedCharacterStatistics stats;
        
        public void SetOwner(Owner owner)
        {
            stats.Init(Config.Stats);
            Owner = owner;
        }
        
        public virtual void Awake()
        {
            AddProperty("Transform", transform);
            AddProperty("GameObject", gameObject);
            AddProperty("Stats", stats);
        }
        
        public void Select()
        {
            transform.localScale = Vector3.one * 1.2f;
        }

        public void Deselect()
        {
            transform.localScale = Vector3.one;
        }


        public void DestroySelf()
        {
            Destroy(gameObject);
        }
    }
}