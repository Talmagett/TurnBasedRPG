using Game.Gameplay.Abilities.Scripts;
using Game.Gameplay.Characters.Scripts.Components;
using Game.Gameplay.EventBus.Events;
using UnityEngine;

namespace Game.Gameplay.Characters.Enemies.Scripts
{
    public class Skeleton : EnemyAI
    {
        [SerializeField] private AbilityConfig dealDamageAbility;

        public override void Run()
        {
            var target = BattleContainer.GetRandomEnemy(CharacterEntity);
            Debug.Log(CharacterEntity.Get<Component_Owner>().owner);
            Debug.Log(target.Get<Component_Owner>().owner);
            EventBus.RaiseEvent(new CastAbilityEvent(CharacterEntity, target, dealDamageAbility));
        }
    }
}