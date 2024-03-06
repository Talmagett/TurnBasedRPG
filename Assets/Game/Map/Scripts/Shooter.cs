using Game.Map.Interactables;
using UnityEngine;

namespace Game.Map.Scripts
{
    public class Shooter : Weapon
    {
        [SerializeField] private float radius;
        
        public override void Attack()
        {
            var hits = Physics.OverlapSphere(transform.position, radius);
            foreach (var hit in hits)
            {
                if (hit.TryGetComponent(out IShootable iShootable))
                {
                    iShootable.Shoot();
                }
            }
        }
    }
}