using UnityEngine;

namespace Map.Characters.Interactions.Environment
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private WeaponType weaponType;
        [SerializeField] private int level;
        [SerializeField] private float range;

        private readonly RaycastHit[] _results=null;
        public void Attack()
        {
            var size = Physics.SphereCastNonAlloc(transform.position, 1, transform.forward, _results, range);
            print(size);
            
            for (var i = 0; i < size; i++)
            {
                if (!_results[i].collider.TryGetComponent(out AttackableInteraction attackableInteraction)) continue;
                
                if(attackableInteraction.CanAttack(weaponType,level))
                    attackableInteraction.Destroy();
            }
        }
    }
}