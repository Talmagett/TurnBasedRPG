using Battle.AbilityContainers;
using Battle.Core;
using Battle.Player;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Battle.Abilities
{
    public class ProjectileShootAbility:Ability
    {
        private readonly ProjectileShootContainer.Data _dto;

        public ProjectileShootAbility(ProjectileShootContainer.Data dto,BattleUnit battleUnit, IAbilityCaster caster) : base(battleUnit, caster)
        {
            _dto = dto;
        }

        public override void StartAbility()
        {
            TryShoot().Forget();
        }
        
        private async UniTask TryShoot()
        {
            var targetResult = await Caster.GetTarget();
            if (targetResult == null) return;

            var shotProjectile = GameObject.Instantiate(_dto.Projectile, BattleUnit.BodyParts.ShootPoint.transform.position,Quaternion.identity);
            
            var targetDir = (targetResult.Point);
            targetDir.y = shotProjectile.transform.position.y;
            shotProjectile.transform.LookAt(targetDir);
            
            var hitTarget = await shotProjectile.Shoot(_dto.ArrowSpeed,_dto.LifeTime,BattleUnit.transform);
            GameObject.Destroy(shotProjectile.gameObject);
            if(hitTarget)
                hitTarget.TakeDamage(_dto.Damage);
            BattleUnit.EndTurn();
        }
    }
}