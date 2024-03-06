using Game.Map.Interactables.Scripts;
using UnityEngine;

namespace Game.Map.Scripts
{
    public class Burner : Weapon
    {
        [SerializeField] private float radius;
        
        public override void Attack()
        {
            var hits = Physics.OverlapSphere(transform.position, radius);
            foreach (var hit in hits)
            {
                if (hit.TryGetComponent(out IBurnable iBurnable))
                {
                    iBurnable.Burn();
                }
            }
        }
    }
}