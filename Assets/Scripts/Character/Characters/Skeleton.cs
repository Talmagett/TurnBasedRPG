using Battle.Actors.Model;
using Battle.Characters;
using Configs.Abilities;
using EventBus.Events;
using UnityEngine;

namespace Character.Characters
{
    public class Skeleton : BattleActor
    {
        [SerializeField] private AbilityConfig dealDamageAbility;
        
        public override void Run()
        {
            var target = BattleContainer.GetRandomEnemy(CharacterEntity);
            Debug.Log(CharacterEntity.Get<Component_Owner>().owner);
            Debug.Log(target.Get<Component_Owner>().owner);
            EventBus.EventBus.RaiseEvent(new CastAbilityEvent(CharacterEntity,target,dealDamageAbility));
        }
    }
}