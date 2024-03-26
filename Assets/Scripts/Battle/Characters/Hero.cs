using Actors;
using Battle.Components;
using Cysharp.Threading.Tasks;
using EventBus.Game.Events;
using UnityEngine;

namespace Battle.Characters
{
    public class Hero: Actor
    {
        [SerializeField] private MeleeAttack biteAttack; 
        //attack
        public override async UniTask Run()
        {
            await UniTask.Delay(500);
            EventBus.RaiseEvent(new VisualParticleEvent(this, biteAttack.hitParticle));
            BattleController.Run();
            await UniTask.Delay(1500);
            EventBus.RaiseEvent(new DealDamageEvent(this,BattleController.GetRandomEnemy(Owner), stats.attackPower.Value));
            EventBus.RaiseEvent(new VisualParticleEvent(BattleController.GetRandomEnemy(Owner), biteAttack.hitParticle));
            BattleController.Run();
        }
    }
}