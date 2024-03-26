using Actors;
using Battle.Components;
using Cysharp.Threading.Tasks;
using Lessons.Game.Events;
using UnityEngine;

namespace Battle.Characters
{
    public class Hero: Actor
    {
        [SerializeField] private MeleeAttack biteAttack; 
        //attack
        public override async UniTask Run()
        {
            EventBus.RaiseEvent(new DealDamageEvent(this,BattleController.GetRandomEnemy(Owner), stats.attackPower.Value));
            EventBus.RaiseEvent(new VisualParticleEvent(BattleController.GetRandomEnemy(Owner), biteAttack.hitParticle));
        }
    }
}