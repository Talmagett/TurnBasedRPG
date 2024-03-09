using Tools;
using UnityEngine;

namespace Map.Characters.Interactions.Environment
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private WeaponType weaponType;
        [SerializeField] private int level;
        [SerializeField] private float range;

        public void Attack()
        {
            var hits = Physics.SphereCastAll(transform.position,1, transform.forward,range, Layers.Interactables);

            foreach (var hit in hits)
            {
                if (!hit.collider.TryGetComponent(out AttackableInteraction attackableInteraction)) continue;
                
                if(attackableInteraction.CanAttack(weaponType,level))
                    attackableInteraction.Destroy();
            }
        }
    }
}