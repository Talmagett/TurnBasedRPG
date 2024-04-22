using System;
using UnityEngine;

namespace Game.Scripts.Configs.Abilities
{
    [Serializable]
    public class ShootProjectileCommand : IAbilityCommand
    {
        [SerializeField] private GameObject projectile;

        public void Execute(AbilityEvent abilityEvent, Action action)
        {
            var projectileGO = GameObject.Instantiate(projectile, abilityEvent.Source.transform.position, Quaternion.identity);
        }
    }
}