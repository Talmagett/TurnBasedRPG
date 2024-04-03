using System.Collections.Generic;
using Atomic.Elements;
using Atomic.Objects;
using Configs;
using Configs.Character;
using Configs.Enums;
using UnityEngine;
using PrimeTween;

namespace Battle.Actors
{
    public class ActorData : AtomicObject
    {
        [field: SerializeField] public BodyParts BodyParts { get; private set; }
        public Animator Animator { get; private set; }
        public string ID { get; private set; }
        public Sprite Icon { get; private set; }
        public AnimatorDispatcher AnimatorDispatcher { get; private set; }
        public SharedCharacterStats SharedStats { get; private set; }
        public Owner Owner { get; private set; }
        private AtomicVariable<int> _cooldown = new();
        
        public virtual void Awake()
        {
            AddProperty(AtomicPropertyAPI.TransformKey, transform);
            AddProperty(AtomicPropertyAPI.GameObjectKey, gameObject);
            AddProperty(AtomicPropertyAPI.CooldownKey, _cooldown);
            Animator = GetComponentInChildren<Animator>();
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
            AddProperty(AtomicPropertyAPI.StatsKey, SharedStats);
            var randomTime = Random.Range(1,(int)SharedStats.GetStat(StatKey.ActionRecoverySpeed));
            _cooldown.Value = randomTime;
        }

        public void SetOwner(Owner owner)
        {
            Owner = owner;
        }

        public void Select()
        {
            Tween.Scale(transform, Vector3.one * 1.2f, 0.3f);
            Tween.Position(transform, transform.position+transform.forward * 2, 0.3f);
        }

        public void Deselect()
        {
            Tween.Scale(transform, Vector3.one, 0.3f);
            Tween.Position(transform, transform.position-transform.forward * 2, 0.3f);
        }

        public void DestroySelf()
        {
            Destroy(gameObject);
        }

        public void ConsumeAction()
        {
            if (TryGet(AtomicPropertyAPI.CooldownKey, out AtomicVariable<int> cooldownTimer))
            {
                cooldownTimer.Value = (int)SharedStats.GetStat(StatKey.ActionRecoverySpeed);
            }
        }
    }
}