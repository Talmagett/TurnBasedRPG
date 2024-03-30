using System.Collections.Generic;
using Atomic.Objects;
using Configs;
using UnityEngine;

namespace Battle.Actors
{
    public class ActorData : AtomicObject
    {
        public string ID { get; private set; }
        public Sprite Icon { get; private set; }
        
        [field: SerializeField] public Animator Animator { get; private set; }
        public SharedCharacterStats SharedStats { get; private set; }
        public Owner Owner { get; private set; }

        public virtual void Awake()
        {
            AddProperty("Transform", transform);
            AddProperty("GameObject", gameObject);
            AddProperty("Stats", SharedStats);
        }

        public void Setup(CharacterConfig characterConfig)
        {
            ID = characterConfig.ID;
            Icon = characterConfig.Icon;
        }
        //From heroData or Character Config
        public void InitStats(Dictionary<StatKey, float> stats)
        {
            SharedStats = new SharedCharacterStats(stats);
        }

        public void SetOwner(Owner owner)
        {
            Owner = owner;
        }

        public void SetCurrentHealth(int value)
        {
            SharedStats.SetStat(StatKey.Health, value);
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