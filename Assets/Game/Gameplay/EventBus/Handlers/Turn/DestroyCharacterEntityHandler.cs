using Game.Gameplay.Battle;
using Game.Gameplay.Characters.Scripts.Keys;
using Game.Gameplay.EventBus.Events;
using JetBrains.Annotations;
using UnityEngine;

namespace Game.Gameplay.EventBus.Handlers.Turn
{
    [UsedImplicitly]
    public sealed class DestroyCharacterEntityHandler : BaseHandler<DestroyCharacterEntityEvent>
    {
        private readonly BattleContainer _battleContainer;

        public DestroyCharacterEntityHandler(EventBus eventBus, BattleContainer battleContainer) : base(eventBus)
        {
            _battleContainer = battleContainer;
        }

        protected override void HandleEvent(DestroyCharacterEntityEvent evt)
        {
            _battleContainer.RemoveUnit(evt.Entity);
            evt.Entity.Get<Animator>().SetTrigger(AnimationKey.GetAnimation(AnimationKey.Animation.Death));
            Object.Destroy(evt.Entity.Get<GameObject>(), 2);
        }
    }
}