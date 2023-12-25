using Battle.Abilities;
using Battle.Core;
using Battle.Mechanics;
using Battle.Player;
using UnityEngine;

namespace Battle.AbilityContainers
{
    public class ProjectileShootContainer : AbilityContainer
    {
        [SerializeField] private Data data;

        [System.Serializable]
        public class Data
        {
            [field:SerializeField] public float Damage{get;private set;}
            [field:SerializeField] public float ArrowSpeed{get;private set;}
            [field:SerializeField] public float LifeTime{get;private set;}
            [field:SerializeField] public Projectile Projectile{get;private set;}
            [field:SerializeField] public ParticleSystem OnHitParticle{get;private set;}
        }

        public override Ability CreateAbility(BattleUnit owner, IAbilityCaster casterType)
        {
            return new ProjectileShootAbility(data,owner,casterType);
        }
    }
}