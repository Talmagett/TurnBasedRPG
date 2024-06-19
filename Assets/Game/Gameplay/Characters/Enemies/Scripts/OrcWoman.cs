using Game.Gameplay.Abilities.Scripts;
using Game.Gameplay.Characters.Scripts.Components;
using Game.Gameplay.EventBus.Events;
using UnityEngine;

namespace Game.Gameplay.Characters.Enemies.Scripts
{
    public class OrcWoman : EnemyAI
    {
        [SerializeField] private AbilityConfig dealDamageAbility;
        [SerializeField] private AbilityConfig healingHasteAbility;
        
        private int _counter=0;
        public override void Run()
        {
            var target = BattleContainer.GetRandomEnemy(CharacterEntity);

            if(_counter<2)
            {
                EventBus.RaiseEvent(new CastAbilityEvent(CharacterEntity, target, dealDamageAbility));
                _counter++;
            }
            else
            {
                _counter = 0;
                EventBus.RaiseEvent(new CastAbilityEvent(CharacterEntity, target, healingHasteAbility));
            }
        }
    }
}