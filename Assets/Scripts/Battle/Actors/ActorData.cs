using Atomic.Objects;
using Configs;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Battle.Actors
{
    public class ActorData : AtomicObject
    {
        [field: SerializeField] public CharacterConfig Config { get; private set; }
        [field: SerializeField] public Animator Animator { get; private set; }

        [ReadOnly] public SharedCharacterStatistics stats;


        public Owner Owner { get; private set; }

        public virtual void Awake()
        {
            AddProperty("Transform", transform);
            AddProperty("GameObject", gameObject);
            AddProperty("Stats", stats);
        }


        public void SetOwner(Owner owner)
        {
            stats.Init(Config.Stats);
            Owner = owner;
        }

        public void SetCurrentHealth(int value)
        {
            stats.Stats[StatKeys.Health] = value;
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