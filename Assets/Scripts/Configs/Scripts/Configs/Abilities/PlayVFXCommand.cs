using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Game.Scripts.Configs.Abilities
{
    [Serializable]
    public class PlayVFXCommand : IAbilityCommand
    {
        [SerializeField] private GameObject particle;
        [SerializeField] private float destroyTimer = 2;
        
        public void Execute(AbilityEvent abilityEvent, Action action=null)
        {
            var vfx = Object.Instantiate(particle, abilityEvent.Target.transform);
            Object.Destroy(vfx,destroyTimer);
            //maybe after
            action?.Invoke();
        }
    }
}