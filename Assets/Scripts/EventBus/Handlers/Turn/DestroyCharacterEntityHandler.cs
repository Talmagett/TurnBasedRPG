using Battle;
using Battle.Actors;
using Configs.Enums;
using EventBus.Events;
using JetBrains.Annotations;
using UnityEngine;

namespace EventBus.Handlers.Turn
{
    [UsedImplicitly]
    public sealed class DestroyCharacterEntityHandler : BaseHandler<DestroyCharacterEntityEvent>
    {
        private readonly BattleContainer _battleContainer;

        public DestroyCharacterEntityHandler(BattleContainer battleContainer)
        {
            _battleContainer = battleContainer;
        }
        protected override void HandleEvent(DestroyCharacterEntityEvent evt)
        {
                _battleContainer.RemoveUnit(evt.Entity);
                evt.Entity.Get<Animator>().SetTrigger(AnimationKey.GetAnimation(AnimationKey.Animation.Death));
                GameObject.Destroy(evt.Entity.Get<GameObject>(),2);
        }
    }
}

