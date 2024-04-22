using System;
using UnityEngine;

namespace Game.Scripts.Configs.Abilities
{
    [Serializable]
    public class PlaySoundCommand : IAbilityCommand
    {
        [SerializeField] private AudioClip sound;

        public void Execute(AbilityEvent abilityEvent, Action action=null)
        {
            AudioSource.PlayClipAtPoint(sound, abilityEvent.Target.transform.position);
            action?.Invoke();
        }
    }
}