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
            EventBus.RaiseEvent(new CastAbilityEvent(CharacterEntity, target, dealDamageAbility));
        }
    }
}