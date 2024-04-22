using Game.Scripts.Configs.Abilities;
using UnityEngine;

namespace Game.Scripts.Configs
{
    public class SingleDamageAbility : AbilityConfig
    {
        [SerializeField] private DealDamageCommand dealDamageCommand;
        [SerializeField] private PlayVFXCommand playVFXCommand;
        [SerializeField] private PlaySoundCommand playSoundCommand;

        public override void Run(AbilityEvent abilityEvent)
        {
            dealDamageCommand?.Execute(abilityEvent);
            playVFXCommand?.Execute(abilityEvent);
            playSoundCommand?.Execute(abilityEvent);
        }
    }
}