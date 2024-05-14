using Character.Components;
using Configs.Abilities;
using EventBus.Events;
using UnityEngine;

namespace Character.Enemies
{
    public class Skeleton : EnemyAI
    {
        [SerializeField] private AbilityConfig dealDamageAbility;

        public override void Run()
        {
            var target = BattleContainer.GetRandomEnemy(CharacterEntity);
            Debug.Log(CharacterEntity.Get<Component_Owner>().owner);
            Debug.Log(target.Get<Component_Owner>().owner);
            EventBus.EventBus.RaiseEvent(new CastAbilityEvent(CharacterEntity, target, dealDamageAbility));
        }
    }
}