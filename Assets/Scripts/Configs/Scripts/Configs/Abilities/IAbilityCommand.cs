using System;

namespace Game.Scripts.Configs.Abilities
{
    public interface IAbilityCommand
    {
        void Execute(AbilityEvent abilityEvent, Action action=null);
    }
}