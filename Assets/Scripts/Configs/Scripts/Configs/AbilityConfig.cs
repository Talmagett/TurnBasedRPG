using System.Collections.Generic;
using Game.Scripts.Configs.Abilities;
using UnityEngine;

namespace Game.Scripts.Configs
{
    [CreateAssetMenu(fileName = "Ability", menuName = "SO/Create Ability", order = 0)]
    public class AbilityConfig : ScriptableObject
    {
        [field: SerializeField] public string GetDescription { get; private set; }
        [SerializeReference] private List<IAbilityCommand> AbilityCommands;
        
        //like quest system
        public virtual void Run(AbilityEvent abilityEvent)
        {
            
        }
    }
}