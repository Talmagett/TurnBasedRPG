using System.Collections.Generic;
using Atomic.Objects;
using Configs;
using Configs.Enums;
using UnityEngine;

namespace Battle.Actors
{
    public class ActorData : AtomicObject
    {
        [field: SerializeField] public Animator Animator { get; private set; }
        public string ID { get; private set; }
        public Sprite Icon { get; private set; }
        public AnimatorDispatcher AnimatorDispatcher { get; private set; }
        public SharedCharacterStats SharedStats { get; private set; }
        public Owner Owner { get; private set; }

        public virtual void Awake()
        {
            AddProperty("Transform", transform);
            AddProperty("GameObject", gameObject);

            AnimatorDispatcher = Animator.GetComponent<AnimatorDispatcher>();
        }

        public void Setup(string id, Sprite icon)
        {
            ID = id;
            Icon = icon;
        }

        //From heroData or Character Config
        public void InitStats(Dictionary<StatKey, float> stats)
        {
            SharedStats = new SharedCharacterStats(stats);
            AddProperty("Stats", SharedStats);
        }

        public void SetOwner(Owner owner)
        {
            Owner = owner;
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