using Battle.Mechanics;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Battle.Abilities
{
    public class ArrowAttack:Ability
    {
        [SerializeField] private float baseDamage;
        [SerializeField] private float baseArrowSpeed;
        [SerializeField] private Projectile projectile;
        [SerializeField] private ParticleSystem onHitParticle;
        public override void StartAbility()
        {
            TryShoot().Forget();
        }

        private async UniTask TryShoot()
        {
            var targetResult = await PlayerController.GetPoint();
            if (targetResult == null) return;

            var shotProjectile = Instantiate(projectile, BattleUnit.BodyParts.ShootPoint);
            shotProjectile.transform.LookAt(targetResult.Point);
            var hitTarget = await shotProjectile.Shoot(baseArrowSpeed);
            Destroy(shotProjectile.gameObject);
            hitTarget.TakeDamage(baseDamage);
            BattleUnit.EndTurn();
        }
    }
}